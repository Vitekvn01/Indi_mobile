using UnityEngine;
using Zenject;

public class PetsStorageInstaller : MonoInstaller
{
    [SerializeField] private PetsStorage petsStorage;
    public override void InstallBindings()
    {
        Container.Bind<PetsStorage>().FromInstance(petsStorage).AsSingle();
    }
}