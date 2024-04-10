using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyDefaults : MonoBehaviour
{
    private Rigidbody targetRb;
    private bool isKinematic = false;
    private bool useGravity = true;

    private void Start()
    {
        if(targetRb == null)
        {
            targetRb = GetComponent<Rigidbody>();
        }
        if(targetRb == null)
        {
            Destroy(this);
        }
        SetupDefaults();
    }

    private void SetupDefaults()
    {
        isKinematic = targetRb.isKinematic;
        useGravity = targetRb.useGravity;
    }

    public void SuspendRigidbody()
    {
        targetRb.isKinematic = true;
        targetRb.useGravity = false;
    }

    public void ResetToDefaults()
    {
        targetRb.isKinematic = isKinematic;
        targetRb.useGravity = useGravity;
    }
}
