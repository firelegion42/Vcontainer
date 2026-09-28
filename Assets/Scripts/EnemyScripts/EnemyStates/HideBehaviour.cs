using UnityEngine;
using VContainer;

public class HideBehaviour : EnemyBehaviour
{
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private AnimationCurve _healthCurve;
    private GameObject[] hideTargets;

    [Inject] private void Construct(HidePoints hidePoints)
    {
        hideTargets = hidePoints._hidePoints;
    }

    public override float Evaluate()
    {
        float _healthPercent = _health.HealthPercent;
        float healthUtility = _healthCurve.Evaluate(1-_healthPercent);
        float distance = Vector3.Distance(transform.position, _player.position);
        float distanceUtility = _utilityCurve.Evaluate(1 - distance / _radius);
        float utility = healthUtility + distanceUtility;
       
            return Mathf.Clamp01(utility);
    }

    public override void Execute()
    {
        moveSpeedCoef = 0.5f;

        agent.speed = _moveSpeed * moveSpeedCoef;

        Debug.Log("Entered Hide");

        Transform bestTarget = FindClosestTarget();

        agent.destination = bestTarget.position;


    }

    private Transform FindClosestTarget()
    {
        Transform bestTarget = null;
        {
            Vector3 currentposition = agent.transform.position;
            float closestDistance = float.MaxValue;

            foreach (GameObject obj in hideTargets)
            {
                Vector3 differenceToTarget = obj.transform.position - currentposition;
                float distance = differenceToTarget.sqrMagnitude;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    bestTarget = obj.transform;
                    Debug.Log("Found Closest Hide");
                }
            }

            return bestTarget;
        }
    }
}

