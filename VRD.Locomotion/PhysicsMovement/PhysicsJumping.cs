using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsJumping : MonoBehaviour
{
    [SerializeField]
    private Rigidbody body;
    [SerializeField]
    private InputActionReference jump;
    [SerializeField]
    private float jumpForce = 100f;
    [SerializeField]
    private int maxJumpCount = 1;
    [SerializeField]
    private int jumpCount = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        jump.action.performed += OnJump;
    }

    private void OnDisable()
    {
        jump.action.performed -= OnJump;
    }

    private void Update()
    {
        if(Mathf.Approximately(body.velocity.y, 0f) && jumpCount >= maxJumpCount)
        {
            jumpCount = 0;
        }
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (jumpCount < maxJumpCount)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount += 1;
        }
    }

    
}
