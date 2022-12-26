using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class SteeringWheel : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] _steeringWheels = default;

        [SerializeField] private float _steeringAngle = default;

        private void Update()
        {
            ControllCarRotating();
        }

        public void ControllCarRotating()
        {
            foreach(WheelCollider wheel in _steeringWheels)
            {
                wheel.steerAngle = _steeringAngle * Input.GetAxis("Horizontal");
            }
        }
    }
}