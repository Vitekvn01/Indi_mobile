using UnityEngine;
using Zenject;

public class MobileInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<DesktopInput>().AsSingle();
    }
}