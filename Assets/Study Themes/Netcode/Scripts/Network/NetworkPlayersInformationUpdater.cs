using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using StudyProject.Extensions;

namespace StudyProject.NetcodeLearning
{
    public class NetworkPlayersInformationUpdater : NetworkBehaviour
    {
        public Action UpdateAction;
        
        [SerializeField] private float _updateTick = default;
        private Coroutine _updateCoroutine;

        private void Start()
        {
            _updateCoroutine = StartCoroutine(UpdateInformationByTick(_updateTick));
        }
            
        private void OnDisable()
        {
            _updateCoroutine.KillCoroutine();
        }

        private IEnumerator UpdateInformationByTick(float tick)
        {
            while(true)
            {
                UpdateAction?.Invoke();
                yield return new WaitForSeconds(tick);
            }
        }
    }
}