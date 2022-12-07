using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Zenject
{
    public class CubeObject : MonoBehaviour
    {
        public void Calculate(int a, int b)
		{
            Debug.Log($"a + b = {a + b}");
		}
    }
}