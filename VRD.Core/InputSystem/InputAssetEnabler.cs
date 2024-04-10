using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRD.Input
{
    /// <summary>
    /// Use this class to automatically enable and disable all inputs of type <see cref="InputAction"/>
    /// </summary>
    /// <remarks>
    /// Actions are initially disabled, so they won't listen/react to input. Use this component
    /// to mass enable actions so that they actively listenf or input and run the appropriate callbacks.
    /// </remarks>
    /// <seealso cref="InputAction"/>
    public class InputAssetEnabler : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Input action assets to affect when inputs are enabled or disabled.")]
        private List<InputActionAsset> _actionAssets = default;
        /// <summary>
        /// Input action assets to affect when inputs are enabled or disabled.
        /// </summary>
        public List<InputActionAsset> actionAssets 
        { 
            get => _actionAssets;
            set => actionAssets = value ?? throw new ArgumentNullException(nameof(value));
        }

        private void OnEnable()
        {
            foreach (var actionAsset in actionAssets)
            {
                actionAsset?.Enable();
            }
        }

        private void OnDisable()
        {
            foreach(var actionAsset in actionAssets)
            {
                actionAsset?.Disable();
            }
        }
    }
}
