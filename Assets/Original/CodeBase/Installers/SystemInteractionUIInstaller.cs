using UnityEngine;
using Zenject;

public class SystemInteractionUIInstaller : MonoInstaller
{
    [SerializeField] private SystemInteractionUI systemInteractionUI;

    public override void InstallBindings()
    {
        Container.Bind<SystemInteractionUI>().FromInstance(systemInteractionUI).AsSingle();
    }
}