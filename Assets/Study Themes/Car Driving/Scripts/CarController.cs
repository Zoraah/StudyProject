using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.CarDriving
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Engine _engine = default;
        [SerializeField] private Transmission _transmission = default;

        [SerializeField] private Vector2 _inputValues = default;

        private void Update()
        {
            ReadInput();
            ControllEngine();
            ControllTransmission();
        }

        private void ReadInput()
        {
            _inputValues.x = Input.GetAxisRaw("Horizontal");
            _inputValues.y = Input.GetAxisRaw("Vertical");
        }

        private void ControllEngine()
        {
            _engine.Gas(_inputValues.y);
        }

        private void ControllTransmission()
		{
            if(Input.GetKeyDown(KeyCode.LeftShift))
			{
                _transmission.IncreaseGear();
			}
            if(Input.GetKeyDown(KeyCode.LeftControl))
			{
                _transmission.DecreaseGear();
			}
        }
    }
}