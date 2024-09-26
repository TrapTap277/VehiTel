using _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts;
using _Scripts.TextWriters;
using UnityEngine;

namespace _Scripts.Car.Checker
{
    public class RpmChecker : Writer, ICheck
    {
        public RpmChecker(DataWriter dataWriter)
        {
            DataWriter = dataWriter;
        }

        private void CheckRpm()
        {
            var result = Dashboard.Rpm / 100;

            if (result < 0) result *= -1;

            Write(DataType.RpmChecker, $"RPM: {Mathf.RoundToInt(result)} r/min");
        }

        public void Check()
        {
            CheckRpm();
        }
    }
}