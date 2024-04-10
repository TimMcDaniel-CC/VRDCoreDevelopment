using UnityEngine;
using UnityEngine.InputSystem;

public class TransformSmoothMove : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveAction;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float moveSpeed = 10f;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
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
        Vector3 playerFacing = Camera.main.transform.forward;
        int forward = moveInput.y > 0f ? 1 : -1;

        Vector3 movementVector = new Vector3(playerFacing.x, 0f, playerFacing.z) * forward;

        Vector3 movementCalculation = movementVector * moveSpeed * Time.deltaTime;
        playerTransform.Translate(movementCalculation);
    }
    
}
