using System.Resources;
using UnityEngine;
using Zenject;

public class GatchaSystemInstaller : MonoInstaller
{
    [SerializeField] private GatchaGlobal gatchaGlobal;
    public override void InstallBindings()
    {
        Container.Bind<IGatchaSysteam>().To<GatchaGlobal>().FromInstance(gatchaGlobal);
    }
}