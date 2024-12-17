using UnityEngine;
using Zenject;

public class GridInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGrid>().To<Grid>().AsSingle();
    }
}