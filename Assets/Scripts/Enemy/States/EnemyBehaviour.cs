using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using VContainer;

public abstract class EnemyBehaviour: MonoBehaviour, IBehaviour
{
    [SerializeField] protected AnimationCurve _utilityCurve;   
    [SerializeField] protected NavMeshAgent agent;
    protected float _moveSpeed;
    protected Transform _player;
    protected float _radius;
    protected BehaviourManager behaviourManager;
    
    protected float moveSpeedCoef;

    [Inject]
    private void Construct(PlayerInput player, Settings settings)
    {
        _player = player.transform;
        _moveSpeed = settings.enemyMovementSpeed;
        _radius = settings.searchRadius;

    }


    public void Init(BehaviourManager behaviour)
    {
        behaviourManager = behaviour;
    }

    public abstract float Evaluate();


    public abstract void Execute();
  
}
