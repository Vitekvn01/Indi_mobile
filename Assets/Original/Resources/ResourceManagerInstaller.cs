using UnityEngine;
using Zenject;

public class ResourceManagerInstaller : MonoInstaller
{
    [SerializeField] private ResourceManager resourceManager;

    public override void InstallBindings()
    {
        Container.Bind<IResourceManager>().To<ResourceManager>().FromComponentInNewPrefab(resourceManager).AsSingle();
        Container.QueueForInject(resourceManager);
    }
}