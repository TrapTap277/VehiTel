using _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts;
using UnityEngine;
using VehiclePhysics;

namespace _Scripts.Car.Data
{
    public class CarData : MonoBehaviour
    {
        public float maxDetectionDistance = 20;
        public VehicleSetupDialog vehicleSetupDialog;
        public VPTelemetry window;
        public Camera carCamera;
        public GameObject car;
    }
}