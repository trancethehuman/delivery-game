using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerControls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    private PlayerControls playerInputActions;

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }


    void Start()
    {
        playerInputActions = new PlayerControls();
        playerInputActions.Player.SetCallbacks(this);

        playerInputActions.Player.Enable();

    }

    private void OnDestroy()
    {
        playerInputActions.Player.Disable();
    }
}