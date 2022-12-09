using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Zenject
{
	public class CalculateScript : MonoBehaviour
	{
		public void Calculate(int a, int b)
		{
			Debug.Log($"{a} + {b} = {a + b}");
		}
	}
}