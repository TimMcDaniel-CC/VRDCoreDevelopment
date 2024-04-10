using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsSimpleMove : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveAction;
    [SerializeField]
    private Transform playerHead;
    [SerializeField]
    private Rigidbody playerRb;
    [SerializeField]
    private float moveSpeed = 10f;

    private Vector3 movementCalculation;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        moveAction.action.performed += OnMove;
    }

    private void OnDisable()
    {
        moveAction.action.performed -= OnMove;
    }

  

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        ForwardMovement(moveInput);
        
        
    }

    private void ForwardMovement(Vector2 direction)
    {
        Vector3 playerFacing = playerHead.forward;

        int forward = direction.y > 0f ? 1 : -1;

        Vector3 movementVector = new Vector3(playerFacing.x, 0f, playerFacing.z * forward);
        movementCalculation = movementVector * moveSpeed * Time.fixedDeltaTime;
        playerRb.position += movementCalculation;

    }


}
