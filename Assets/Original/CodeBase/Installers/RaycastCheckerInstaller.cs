using UnityEngine;
using Zenject;

public class RaycastCheckerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRaycastChecker>().To<RaycastChecker>().AsSingle();
    }
}