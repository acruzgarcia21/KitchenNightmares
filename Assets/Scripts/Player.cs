using System;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // SerializeField allows private fields to be manipulated in the engine
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;

    private bool _isWalking;
    private Vector3 _lastInteractDir;
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // Ensures that the engine knows that something is in front of the player even without moving
        if (moveDir != Vector3.zero)
        {
            _lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position,
                _lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // Has clear counter
                clearCounter.Interact();
            }
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .7f;
        float playerHeight = 2f;
        Vector3 playerTop = transform.position + Vector3.up * playerHeight;
        float moveDistance = moveSpeed * Time.deltaTime;
        
        bool canMove = !Physics.CapsuleCast(
            transform.position,       // Bottom of the player
            playerTop,                // top of the player
            playerRadius,                   // How wide the player is
            moveDir,                // Which direction to check
            moveDistance);                  // How far to check

        if (!canMove)
        {
            // Cannot move towards moveDir
            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(
                transform.position,       
                playerTop,                
                playerRadius,                   
                moveDirX,   // Switch to move in only direction x
                moveDistance);                  
            if (canMove)
            {
                // Can move only in the X direction
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X
                
                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(
                    transform.position,
                    playerTop,
                    playerRadius,
                    moveDirZ,   // Switch to move in only direction z
                    moveDistance);
                if (canMove)
                {
                    // Can only move on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
            
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance; // Delta time makes it Frame independent
        }

        _isWalking = moveDir != Vector3.zero;

        // Functions that update the position of where the player is looking at:
        //      .position
        //      .eulerAngles
        //      .lookAt
        //      .forward
        const float rotateSpeed = 12f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
