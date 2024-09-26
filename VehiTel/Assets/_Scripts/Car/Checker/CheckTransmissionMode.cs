using _Scripts.Car.Data;
using _Scripts.TextWriters;

namespace _Scripts.Car.Checker
{
    public class CheckTransmissionMode : Writer, ICheck
    {
        private readonly CarData _carData;

        public CheckTransmissionMode(CarData carData, DataWriter dataWriter)
        {
            _carData = carData;
            DataWriter = dataWriter;
        }

        public void Check()
        {
            Write(DataType.CheckTransmissionMode,
                $"Transmission Mode: {(_carData.vehicleSetupDialog.automaticTransmission.isOn ? "Automatic" : "Manual")}");
        }
    }
}