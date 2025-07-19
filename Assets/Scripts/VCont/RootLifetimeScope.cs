using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    //[SerializeField] VContUnit unitPrefab;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MainGC>();
        //builder.RegisterComponentInNewPrefab<VContUnit>(unitPrefab, Lifetime.Singleton);
    }
}
