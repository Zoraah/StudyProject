using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.Zenject
{
	public class ObjectsInitializer : MonoBehaviour
	{
		[Inject] [SerializeField] private CalculateScript _calculateScriptObject = default;
		[SerializeField] private GameObject _cubeObject = default;

		public void Awake()
		{
			InitializeGameObject();
		}

		public void InitializeGameObject()
		{

		}
	}
}