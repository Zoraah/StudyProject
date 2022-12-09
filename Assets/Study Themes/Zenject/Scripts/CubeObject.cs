using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.Zenject
{
    public class CubeObject : MonoBehaviour
    {
        [Inject] [SerializeField] private CalculateScript _calculateObject;

        [SerializeField] private int _aValue = default;
        [SerializeField] private int _bValue = default;

		private void OnMouseDown()
		{
            _calculateObject.Calculate(_aValue, _bValue);	
		}

        public void SetCalculateObject(CalculateScript calculateScript)
        {
            _calculateObject = calculateScript;
        }
    }
}