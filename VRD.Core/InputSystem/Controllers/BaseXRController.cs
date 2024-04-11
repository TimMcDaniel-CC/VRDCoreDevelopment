using UnityEngine;
using UnityEngine.InputSystem;

namespace VRD.Input
{
    public class BaseXRController : MonoBehaviour
    {
        [SerializeField]
        protected InputActionProperty trigger;
        [SerializeField]
        protected InputActionProperty triggerPressed;
        [SerializeField]
        protected InputActionProperty grip;
        [SerializeField]
        protected InputActionProperty gripPressed;
        [SerializeField]
        protected InputActionProperty primary2DAxis;
        [SerializeField]
        protected InputActionProperty primary2DAxisPressed;

        public virtual InputAction Trigger
        {
            get => trigger.action; 
        }

        public virtual InputAction TriggerPressed
        {
            get => triggerPressed.action;
        }

        public virtual InputAction Grip
        {
            get => grip.action;
        }

        public virtual InputAction GripPressed
        {
            get => gripPressed.action;
        }

        public virtual InputAction Primary2DAxis
        {
            get => primary2DAxis.action;
        }

        public virtual InputAction Primary2DAxixPressed
        {
            get => primary2DAxisPressed.action;
        }

    }
}
