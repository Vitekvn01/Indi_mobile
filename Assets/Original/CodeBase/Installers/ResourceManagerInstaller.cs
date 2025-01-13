using UnityEngine;
using Zenject;

public class ResourceManagerInstaller : MonoInstaller
{
    [SerializeField] private ResourceManager _resourceManager;

    public override void InstallBindings()
    {
        Container.Bind<IResourceManager>().To<ResourceManager>().FromInstance(_resourceManager).AsSingle();
    }
}