using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Engine _engine = default;
        [SerializeField] private SteeringWheel _steeringWheel = default;

        private Vector2 _inputValues = default;

        private void Update()
        {
            ReadInput();
            ControllEngine();
        }

        private void ReadInput()
        {
            _inputValues.x = Input.GetAxis("Horizontal");
            _inputValues.y = Input.GetAxis("Vertical");
        }

        private void ControllEngine()
        {
            if(_inputValues.y > 0)
            {
                _engine.Gas();
            }
            else if(_inputValues.y < 0)
            {
                _engine.Break(true);
            }
            else
            {
                _engine.Break(false);
            }
        }
    }
}