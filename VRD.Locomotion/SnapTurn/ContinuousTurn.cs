using UnityEngine;
using UnityEngine.InputSystem;

namespace Cochise.VRD
{
    public class ContinuousTurn : MonoBehaviour
    {
        [SerializeField]
        protected InputActionProperty inputAction;
        [SerializeField]
        protected Transform playerRig;
        [SerializeField]
        protected float rotationAngle = 45f;
        
        protected virtual void OnEnable()
        {
            inputAction.action.performed += ApplyRotation;    
        }
        protected virtual void OnDisable()
        {
            inputAction.action.performed -= ApplyRotation;
        }
        
        protected virtual void ApplyRotation(InputAction.CallbackContext context)
        {        
            float yRot = context.ReadValue<Vector2>().x > 0 ? rotationAngle : -rotationAngle;
            playerRig.transform.RotateAround(Camera.main.transform.position, transform.up, yRot);
        }
    }
}
