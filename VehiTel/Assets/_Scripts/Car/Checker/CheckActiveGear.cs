using _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts;
using _Scripts.TextWriters;
using Unity.VisualScripting;

namespace _Scripts.Car.Checker
{
    public class CheckActiveGear : Writer, ICheck
    {
        public CheckActiveGear(DataWriter dataWriter)
        {
            DataWriter = dataWriter;
        }

        public void Check()
        {
            SetActiveGear();
        }

        private void SetActiveGear()
        {
            Write(DataType.CheckActiveGear, $"Active Gear: {GearModeSelector.CurrentGear.ToSafeString()}");
        }
    }
}