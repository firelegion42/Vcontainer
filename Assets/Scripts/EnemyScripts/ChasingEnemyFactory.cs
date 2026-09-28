using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ChasingEnemyFactory
{
    private IObjectResolver _resolver;
    private BehaviourManager _enemy;
    private Settings _settings;

    public ChasingEnemyFactory(IObjectResolver resolver, BehaviourManager enemy, Settings settings)
    {
        _resolver = resolver;
        _enemy = enemy;
        _settings = settings;
    }

    public BehaviourManager Create() => _resolver.Instantiate(_enemy);
  
}
