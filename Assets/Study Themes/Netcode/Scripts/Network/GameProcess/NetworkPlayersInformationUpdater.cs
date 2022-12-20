using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using StudyProject.ProjectExtensions;

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

		private void OnApplicationQuit()
		{
            _updateCoroutine.KillCoroutine(this);
        }

		public override void OnDestroy()
        {
            base.OnDestroy();
            _updateCoroutine.KillCoroutine(this);
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