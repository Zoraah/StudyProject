using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.NetcodeLearning
{
    public class NetworkSceneInstaller : MonoInstaller
    {
        [SerializeField] private NetworkPlayersInformationUpdater _networkPlayersInformationUpdater;

        [SerializeField] private ObjectSpawer _objectSpawner = default;

        public override void InstallBindings()
        {
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            Container.BindInstance<NetworkPlayersInformationUpdater>(_networkPlayersInformationUpdater).AsSingle().NonLazy();
        }
    }
}