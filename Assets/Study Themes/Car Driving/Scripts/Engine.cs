using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class Engine : MonoBehaviour
    {
        [SerializeField] private Rigidbody _carRigidbody = default;

        [SerializeField] private Transmission _transmission = default;
        [SerializeField] private WheelDrive _wheelDrive = default;

        [SerializeField] private int _HP = default;
        [SerializeField] private float _increaseSpeedValue = default;
        
        [SerializeField] private string _status = default;
        [SerializeField] private float _speed = default;
        
        public int HP => _HP;

        private void LateUpdate()
        {
            _speed = (float)_carRigidbody.velocity.magnitude * 3.6f;

            Debug.Log("Speed: " + _speed);
        }

        public void Gas()
        {

            float currentIncreaseSpeedValue = _increaseSpeedValue * _transmission.GetCurrentIncreseValue(_speed);

            if(_speed < _transmission.CurrentTransmissionGear.MaxSpeed)
            {
                _wheelDrive.SetWheelTorque(currentIncreaseSpeedValue);
            }
            else
            {
                _wheelDrive.SetWheelTorque(0f);
            }
        }

        public void Break(bool isBreak)
        {
            _wheelDrive.Break(isBreak);
            if(isBreak)
            {
                
            }
            else
            {
                _wheelDrive.SetWheelTorque(0f);  
            }
        }
    }
}