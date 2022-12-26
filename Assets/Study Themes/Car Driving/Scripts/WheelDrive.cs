using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class WheelDrive : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] _motorWheels = default;

        public float CircumFerence => 2.0f * Mathf.PI * _motorWheels[0].radius;

        public void SetWheelTorque(float motorTorque)
        {
            foreach(WheelCollider wheelCollider in _motorWheels)
            {
                wheelCollider.motorTorque = motorTorque;
            }
        }

        public void Break(bool isBreak)
        {
            foreach(WheelCollider wheelCollider in _motorWheels)
            {
                if(isBreak)
                {
                    wheelCollider.brakeTorque = 1000f;
                }
                else
                {
                    wheelCollider.brakeTorque = 0f;
                }
            }
        }

        public float GetWheelsTorgue()
        {
            float torgue = 0;

            foreach(WheelCollider wheelCollider in _motorWheels)
            {
                torgue += wheelCollider.motorTorque;
            }
            
            torgue = torgue / _motorWheels.Length;

            return torgue;
        }
    }
}