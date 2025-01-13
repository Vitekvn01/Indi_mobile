using System.ComponentModel;
using System.Resources;
using UnityEngine;
using Zenject;

public class BuildShopManagerInstaller : MonoInstaller
{
    [SerializeField] private BuildShopManager _BuildShopManager;
    public override void InstallBindings()
    {
        Container.Bind<IBuildShopManager>().To<BuildShopManager>().FromInstance(_BuildShopManager).AsSingle();
    }
}
