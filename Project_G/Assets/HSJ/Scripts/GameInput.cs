using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnFireAction;

    private PlayerInputActions playerInputActions;

    private Vector3 lastMousePosition;

    private const string placementLayermask = "Placement";
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Fire.performed += Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        OnFireAction?.Invoke(this, EventArgs.Empty);        
        Debug.Log("LeftMouse Click");
    }


    public Vector2 GetMovementVectorNormailized()
    {
        Vector2 inputVector = playerInputActions.Player.MoveView.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        
        Vector3 mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;      
        

        if(Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("placementLayermask")))
        {
            lastMousePosition = hit.point;
        }


        return lastMousePosition;
    }


}
