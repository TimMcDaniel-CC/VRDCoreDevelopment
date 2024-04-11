using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cochise.VRD
{
    public class SnapTurn : ContinuousTurn
    {
        private bool canTurn = true;

        protected override void OnEnable()
        {
            base.OnEnable();
            inputAction.action.canceled += EnableTurn;
        }
        protected override void OnDisable() 
        { 
            base.OnDisable();
            inputAction.action.canceled -= EnableTurn;
        }

        private void EnableTurn(InputAction.CallbackContext context)
        {
            canTurn = true;
        }

        protected override void ApplyRotation(InputAction.CallbackContext context)
        {
            if (canTurn)
            {
                canTurn = false;
                base.ApplyRotation(context);
            }
        }
    }
}
