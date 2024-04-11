using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBridge : MonoBehaviour
{
    [SerializeField]
    private BodyAwarenessRaycaster raycaster;
    [SerializeField]
    private BodyPresence bodyPresence;

    private void Update()
    {
        raycaster.BodyHeight = bodyPresence.BodyHeight;        
    }
}
