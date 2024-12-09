using UnityEngine;
using Zenject;

public class PetManagerInstaller : MonoInstaller
{
    [SerializeField] private PetManager petManager;
    public override void InstallBindings()
    {
        Container.Bind<PetManager>().FromInstance(petManager).AsSingle();
    }
}