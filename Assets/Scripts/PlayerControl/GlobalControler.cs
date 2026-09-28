using UnityEngine;

public abstract class GlobalControler : MonoBehaviour
{
    protected IJumpable jump;
    protected IMoveable move;
    protected IAttack attack;

    protected virtual void Awake()
    {
        if(TryGetComponent<IJumpable>(out var jumpComponent))
        {
            jump = jumpComponent;
        }

        if(TryGetComponent<IMoveable>(out var moveComponent))
        {
            move = moveComponent;
        }
        if (TryGetComponent<IAttack>(out var attackComponent))
        {
            attack = attackComponent;
        }
    }
}
