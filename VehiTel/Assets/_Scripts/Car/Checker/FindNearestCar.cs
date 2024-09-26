using _Scripts.Car.Data;
using _Scripts.TextWriters;
using UnityEngine;

namespace _Scripts.Car.Checker
{
    public class FindNearestCar : Writer, ICheck
    {
        private readonly CarData _carData;
        private float _distanceToNextCar;

        public FindNearestCar(CarData carData, DataWriter dataWriter)
        {
            DataWriter = dataWriter;
            _carData = carData;

            WriteNotDefined();
        }

        public void Check()
        {
            SetDistanceToNextCar();
        }

        private void SetDistanceToNextCar()
        {
            var nearestCar = FindCar();

            if (nearestCar != null)
            {
                _distanceToNextCar = Vector3.Distance(_carData.car.transform.position, nearestCar.transform.position);
                var isInFieldOfView = IsInFieldOfView(nearestCar);

                if (isInFieldOfView)
                {
                    if (_distanceToNextCar < 0) _distanceToNextCar *= -1;

                    Write(DataType.FindNearestCar,
                        $"Nearest car: {nearestCar.name}, Distance: {Mathf.RoundToInt(_distanceToNextCar)}");
                }
                else
                {
                    WriteNotDefined();
                }
            }
            else
            {
                _distanceToNextCar = -1f;
            }
        }

        private GameObject FindCar()
        {
            GameObject nearestCar = null;
            var nearestDistance = _carData.maxDetectionDistance;

            var allCars = GameObject.FindGameObjectsWithTag("Car");

            foreach (var car in allCars)
                if (car.gameObject != _carData.car)
                {
                    var distance = Vector3.Distance(_carData.car.transform.position, car.transform.position);
                    if (distance < nearestDistance)
                    {
                        nearestCar = car.gameObject;
                        nearestDistance = distance;
                    }
                }

            return nearestCar;
        }

        private bool IsInFieldOfView(GameObject car)
        {
            if (_carData.carCamera == null) return false;

            if (_distanceToNextCar > _carData.maxDetectionDistance) return false;

            var viewportPoint = _carData.carCamera.WorldToViewportPoint(car.transform.position);
            var inCameraView = viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.x < 1 &&
                               viewportPoint.y > 0 && viewportPoint.y < 1;

            if (!inCameraView) return _distanceToNextCar < _carData.carCamera.nearClipPlane;

            return true;
        }

        private void WriteNotDefined()
        {
            Write(DataType.FindNearestCar, "Nearest Car Not defined!");
        }
    }
}