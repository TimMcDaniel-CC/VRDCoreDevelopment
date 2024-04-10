using UnityEngine;
using UnityEngine.InputSystem;

namespace VRD.Input
{
    public class WMRControllerGen1 : BaseXRController
    {
        [SerializeField]
        protected InputActionProperty secondary2DAxis;
        [SerializeField]
        protected InputActionProperty secondary2DAxisPress;

        public virtual InputAction Secondary2DAxis
        {
            get => secondary2DAxis.action;
        }
        public virtual InputAction Secondary2DAxisPress
        {
            get => secondary2DAxisPress.action;
        }
    }
}
