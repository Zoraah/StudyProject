using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StudyProject.Zenject
{
    public class DefaultSystemInstaller : MonoInstaller
    {
		[SerializeField] private CalculateScript _calculateObject = default;

		public override void InstallBindings()
		{
			Container.Bind<CalculateScript>().FromInstance(_calculateObject).AsSingle().NonLazy();
			Container.QueueForInject(_calculateObject);
		}
	}
}