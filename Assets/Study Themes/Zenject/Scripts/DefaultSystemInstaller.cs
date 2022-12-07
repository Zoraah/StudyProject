using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.Zenject
{
    public class DefaultSystemInstaller : MonoInstaller
    {
		[SerializeField] private CubeObject _cubeObject = default;

		public override void InstallBindings()
		{
			Container.Bind<CubeObject>().FromInstance(_cubeObject).AsSingle().NonLazy();
			Container.QueueForInject(_cubeObject);
		}
	}
}