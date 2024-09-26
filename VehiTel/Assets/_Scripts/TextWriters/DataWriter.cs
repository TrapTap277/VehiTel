using System;
using TMPro;
using UnityEngine;

namespace _Scripts.TextWriters
{
    public class DataWriter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI engineStatusText;
        [SerializeField] private TextMeshProUGUI checkTransmissionMode;
        [SerializeField] private TextMeshProUGUI findNearestCar;
        [SerializeField] private TextMeshProUGUI speedChecker;
        [SerializeField] private TextMeshProUGUI checkActiveGear;
        [SerializeField] private TextMeshProUGUI rpmChecker;

        private TextMeshProUGUI _currentText;

        public void SetText(DataType dataType)
        {
            _currentText = dataType switch
            {
                DataType.EngineStatus => engineStatusText,
                DataType.CheckTransmissionMode => checkTransmissionMode,
                DataType.FindNearestCar => findNearestCar,
                DataType.SpeedChecker => speedChecker,
                DataType.CheckActiveGear => checkActiveGear,
                DataType.RpmChecker => rpmChecker,
                _ => throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null)
            };
        }

        public void Write(string value)
        {
            _currentText.text = value;
        }
    }
}