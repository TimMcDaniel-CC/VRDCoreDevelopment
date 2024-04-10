using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRD.Input
{
    public class XRControllerWithFaceButtons : BaseXRController
    {
        [SerializeField]
        protected InputActionProperty primaryButtonTouch;
        [SerializeField]
        protected InputActionProperty primaryButtonPress;
        [SerializeField]
        protected InputActionProperty secondaryButtonTouch;
        [SerializeField] 
        protected InputActionProperty secondaryButtonPress;

        public virtual InputAction PrimaryButtonTouch
        {
            get => primaryButtonTouch.action;
        }
        public virtual InputAction PrimaryButtonPress
        {
            get => primaryButtonPress.action;
        }

        public virtual InputAction SecondaryButtonTouch
        {
            get => secondaryButtonTouch.action;
        }

        public virtual InputAction SecondaryButtonPress
        { 
            get => secondaryButtonPress.action; 
        }
    }
}
