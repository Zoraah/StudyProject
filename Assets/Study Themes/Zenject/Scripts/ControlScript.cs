using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.Zenject
{
	public class ControlScript : MonoBehaviour
	{
		[Inject] [SerializeField] private CubeObject _cubeObject;

		[SerializeField] private bool _doSomething = false;

		private void Update()
		{
			DoSomething();
		}

		public void DoSomething()
		{
			if (_doSomething)
			{
				_doSomething = false;
				_cubeObject.Calculate(30, 234);
			}
		}
	}
}