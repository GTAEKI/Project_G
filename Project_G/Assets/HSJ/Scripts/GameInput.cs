using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnFireAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Fire.performed += Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        OnFireAction?.Invoke(this, EventArgs.Empty);        
        Debug.Log("Click");
    }

    public Vector3 GetMousePosition()
    {
        Vector2 mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        Debug.Log(mousePosition);
        return mousePosition;
    }


}
