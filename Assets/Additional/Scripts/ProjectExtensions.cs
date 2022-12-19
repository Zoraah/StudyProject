using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Extensions
{
    public static class CoroutineExtensions
    {
        public static void KillCoroutine(this Coroutine coroutine, MonoBehaviour monoBehaviour)
        {
            if(coroutine != null)
            {
                monoBehaviour.StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}