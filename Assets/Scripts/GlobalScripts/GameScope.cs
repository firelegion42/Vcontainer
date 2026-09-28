using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{

    [SerializeField] private Settings settings;
    [SerializeField] private BehaviourManager _chasingEnemy;
    [SerializeField] private GameObject[] _patrolPoints;
    [SerializeField] private GameObject[] _hideTargets;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(settings);

        builder.RegisterComponentInHierarchy<PlayerInput>();
        builder.RegisterComponentInHierarchy<Spawner>();

        builder.Register<ChasingEnemyFactory>(Lifetime.Singleton).WithParameter(_chasingEnemy);

        builder.RegisterInstance(new PatrolPoints(_patrolPoints));
        builder.RegisterInstance(new HidePoints(_hideTargets));

    }
}
