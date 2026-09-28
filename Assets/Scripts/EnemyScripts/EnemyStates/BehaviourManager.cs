using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class BehaviourManager : MonoBehaviour
{
    private EnemyBehaviour _activeBehaviour;

    [SerializeField] private List<EnemyBehaviour> _behaviours;


    private void Start()
    {
        _behaviours = new List<EnemyBehaviour>(GetComponents<EnemyBehaviour>());

        foreach (var behaviour in _behaviours)
        {
            behaviour.Init(this);
        }
        DecideAction();
    }

    private void Update()
    {
        DecideAction();
    }

    public void DecideAction()
    {
        float maxUtility = 0;
        EnemyBehaviour targetBehaviour = null;

        foreach (var behaviour in _behaviours)
        {
            var utility = behaviour.Evaluate();
            if (maxUtility < utility)
            {
                maxUtility = utility;
                targetBehaviour = behaviour;
            }
        }
        _activeBehaviour = targetBehaviour;
        _activeBehaviour.Execute();
    }
}

