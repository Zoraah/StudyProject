using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class Transmission : MonoBehaviour
    {
        [SerializeField] private Engine _engine = default;

        [SerializeField] private TransmissionGear[] _transmissionGears = default;
        private TransmissionGear _currentTransmissionGear = default;
        private byte _currentGearIndex = 0;
        
        private float _currentIncreaseSpeedValue = 0;
        private float _wheelsTorque = 0;

        public TransmissionGear CurrentTransmissionGear => _currentTransmissionGear;

        private void Start()
        {
            _currentGearIndex = 0;
            _currentTransmissionGear = _transmissionGears[_currentGearIndex];

            float speedDiapazone = _currentTransmissionGear.MaxSpeed - _currentTransmissionGear.MinSpeed;
            Debug.Log("Speed diapazone: " + speedDiapazone);
        }

        public void IncreaseGear()
        {
            if(_currentGearIndex < _transmissionGears.Length)
            {
                _currentGearIndex++;
                _currentTransmissionGear = _transmissionGears[_currentGearIndex];
            }
        }

        public void DecreaseGear()
        {
            if(_currentGearIndex > 1)
            {
                _currentGearIndex--;
                _currentTransmissionGear = _transmissionGears[_currentGearIndex];
            }
        }

        public float GetCurrentIncreseValue(float speed)
        {
            float speedDiapazone = _currentTransmissionGear.MaxSpeed - _currentTransmissionGear.MinSpeed;
            Debug.Log("Speed diapazone: " + speedDiapazone);
            float speedInSpeedDiapazone = speed - _currentTransmissionGear.MinSpeed;
            Debug.Log("Speed in speed diapazone:" + speedInSpeedDiapazone);
            float forceSpeedValue = (speedInSpeedDiapazone * 100f) / speedDiapazone / 100f;

            Debug.Log("Force speed value: " + forceSpeedValue);

            float rpm = _currentTransmissionGear.RPMCurve.Evaluate(forceSpeedValue);

            Debug.Log("RPM: " + rpm);

            _currentIncreaseSpeedValue = rpm;

            return _currentIncreaseSpeedValue;
        }
    }
}