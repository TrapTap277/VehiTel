using System.Collections.Generic;
using _Scripts.Car.Checker;
using _Scripts.Car.Data;
using _Scripts.TextWriters;
using UnityEngine;

namespace _Scripts.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private DataWriter dataWriter;
        [SerializeField] private CarData carData;

        private readonly List<ICheck> _checks = new List<ICheck>();

        private CarReader _carReader;

        private void Start()
        {
            _checks.Add(new CheckEngineStatus(carData, dataWriter));
            _checks.Add(new CheckTransmissionMode(carData, dataWriter));
            _checks.Add(new FindNearestCar(carData, dataWriter));
            _checks.Add(new SpeedChecker(carData, dataWriter));
            _checks.Add(new CheckActiveGear(dataWriter));
            _checks.Add(new RpmChecker(dataWriter));

            _carReader = new CarReader(_checks);
        }

        private void Update()
        {
            Check();
        }

        private void Check()
        {
            _carReader.Check();
        }
    }
}