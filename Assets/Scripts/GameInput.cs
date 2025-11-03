using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        // There is only two inputs so there is no need to use a 3D vector for input
        // Reads in the Move mapping system that was created
        // Extracts the current value (Vector2)
        // Stores the result to use for player input
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        
        // // Legacy input
        // if (Input.GetKey(KeyCode.W))
        // {
        //     inputVector.y = +1;
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     inputVector.y = -1;
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     inputVector.x = -1;
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     inputVector.x = +1;
        // }

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
