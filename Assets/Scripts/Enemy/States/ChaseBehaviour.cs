using NUnit.Framework.Constraints;
using UnityEngine;

public class ChaseBehaviour : EnemyBehaviour
{
    public override float Evaluate()
    {
        var distance = Vector3.Distance(transform.position, _player.position);
        var utility = _utilityCurve.Evaluate(1 - distance / _radius);
            return Mathf.Clamp01(utility);
        
    }

    public override void Execute()
    {
        moveSpeedCoef = 1f;

        agent.speed = _moveSpeed * moveSpeedCoef;

        Debug.Log("Entered Patrol");

        agent.destination = _player.transform.position;
    }
}
