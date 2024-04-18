using System;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class InputService : MonoBehaviour
{
    public event Action ShootButtonPressed;
    public event Action<Vector2> MovementJoystickMoved;
    
     
    public void OnMove(InputAction.CallbackContext ctx) => MovementJoystickMoved?.Invoke(ctx.ReadValue<Vector2>());
    public void OnShoot(InputAction.CallbackContext ctx) => ShootButtonPressed?.Invoke();
}
