using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    [SerializeField]
    InputActionReference position;
    [SerializeField]
    InputActionReference rotation;
    [SerializeField]
    InputActionReference tracking;
    [SerializeField]
    InputActionReference velocity;
    [SerializeField]
    InputActionReference triggerTouch;
    [SerializeField]
    InputActionReference grip;


    public Vector3 Velocity
    {
        get { return velocity.action.ReadValue<Vector3>(); }
    }
}
