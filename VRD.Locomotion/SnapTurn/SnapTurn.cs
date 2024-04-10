using UnityEngine;
using UnityEngine.InputSystem;

namespace Cochise.VRD
{
    public class SnapTurn : MonoBehaviour
    {
        [SerializeField]
        private InputActionProperty inputAction;
        [SerializeField]
        private Transform playerRig;
        private float rotationAngle = 45f;
        private bool canTurn = true;


        private void OnEnable()
        {
            inputAction.action.performed += ApplyRotation;
            inputAction.action.canceled += EnableTurn;
        }
        private void OnDisable()
        {
            inputAction.action.performed -= ApplyRotation;
            inputAction.action.canceled -= EnableTurn;
        }
        private void EnableTurn(InputAction.CallbackContext context)
        {
            canTurn = true;
        }
        private void ApplyRotation(InputAction.CallbackContext context)
        {
            if (!canTurn)
            {
                return;
            }
            canTurn = false;
            float yRot = context.ReadValue<Vector2>().x > 0 ? rotationAngle : -rotationAngle;
            playerRig.transform.RotateAround(Camera.main.transform.position, transform.up, yRot);
        }


    }
}
