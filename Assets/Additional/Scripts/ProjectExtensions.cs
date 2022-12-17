using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Extensions
{
    public static class CoroutineExtensions
    {
        public static void KillCoroutine(this Coroutine coroutine)
        {
            if(coroutine != null)
            {
                MonoBehaviour monoBehaviour = new MonoBehaviour();
                monoBehaviour.StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}