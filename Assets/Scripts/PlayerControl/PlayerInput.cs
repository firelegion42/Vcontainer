using UnityEngine;
using UnityEngine.InputSystem; 

public class Controller : GlobalControler
{

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump.Jump();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        move.Move(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attack.Attack();

        }
    }
}
