using UnityEngine;
using VContainer;
using static UnityEngine.GraphicsBuffer;

public class PatrolBehaviour : EnemyBehaviour
{
    protected GameObject[] _targets;

    [Inject]
    private void Construct(PatrolPoints patrolPoints)
    {
        _targets = patrolPoints._patrolPoints;
    }
   


    public override float Evaluate()
    {
        var distance = Vector3.Distance(transform.position, _player.position);
        var utility = _utilityCurve.Evaluate(1 - distance / _radius);
        if(utility > 0)
        {
            return Mathf.Clamp01(utility);
        }
        else
        {
            return 1f;
        }
        
    }

    public override void Execute()
    {
        moveSpeedCoef = 0.8f;

        agent.speed = _moveSpeed * moveSpeedCoef;

        Debug.Log("Entered Patrol");

        Transform bestTarget = FindClosestTarget();

        agent.destination = bestTarget.position;


    }

    private Transform FindClosestTarget()
    {
        Transform bestTarget = null;
        {
            Vector3 currentposition = agent.transform.position;
            float closestDistance = float.MaxValue;

            foreach (GameObject obj in _targets)
            {
                Vector3 differenceToTarget = obj.transform.position - currentposition;
                float distance = differenceToTarget.sqrMagnitude;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    bestTarget = obj.transform;
                    Debug.Log("Found Closest Target");
                }
            }

            return bestTarget;
        }
    }
}
