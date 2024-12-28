using UnityEngine;
using Zenject;

public class BuildShopViewInstaller : MonoInstaller
{
    [SerializeField] private BuildShopView _buildShopView;
    public override void InstallBindings()
    {
        Container.Bind<IBuildShopView>().To<BuildShopView>().FromInstance(_buildShopView).AsSingle();
    }
}