using _Scripts.Car.Data;
using _Scripts.TextWriters;

namespace _Scripts.Car.Checker
{
    public class CheckEngineStatus : Writer, ICheck
    {
        private readonly CarData _carData;

        public CheckEngineStatus(CarData carData, DataWriter dataWriter)
        {
            DataWriter = dataWriter;
            _carData = carData;
        }

        public void Check()
        {
            SetEngineStatus();
        }

        private void SetEngineStatus()
        {
            var engineStatus = _carData.vehicleSetupDialog.engineStall.isOn;

            Write(DataType.EngineStatus, $"Engine Status: {(engineStatus ? "Active" : "Inactive")}");
        }
    }
}