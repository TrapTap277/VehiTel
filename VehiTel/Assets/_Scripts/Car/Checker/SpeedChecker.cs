using _Scripts.Car.Data;
using _Scripts.TextWriters;
using UnityEngine;

namespace _Scripts.Car.Checker
{
    public class SpeedChecker : Writer, ICheck
    {
        private readonly CarData _carData;

        public SpeedChecker(CarData carData, DataWriter dataWriter)
        {
            DataWriter = dataWriter;
            _carData = carData;
        }

        public void Check()
        {
            SetSpeedKm();
        }

        private void SetSpeedKm()
        {
            var speed = _carData.window.vehicle.speed * 3.6f;
            
            if (speed < 0) speed *= -1;
            
            Write(DataType.SpeedChecker, $"Speed: {Mathf.RoundToInt(speed)} km/h");
        }
    }
}