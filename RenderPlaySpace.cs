using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
public class RenderPlaySpace : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> boundaryPoints;
    private XRInputSubsystem inputSubsystem;
    void Start()
    {
        var loader = XRGeneralSettings.Instance?.Manager?.activeLoader;
        if (loader == null)
        {
            Debug.LogWarning("Could not get active Loader.");
            return;
        }
        inputSubsystem = loader.GetLoadedSubsystem<XRInputSubsystem>();
        inputSubsystem.boundaryChanged += InputSubsystem_boundaryChanged;
    }
    private void InputSubsystem_boundaryChanged(XRInputSubsystem inputSubsystem)
    {
        boundaryPoints = new List<Vector3>();
        if (inputSubsystem.TryGetBoundaryPoints(boundaryPoints))
        {
            
        }
        else
        {
            Debug.LogWarning($"Could not get Boundary Points for Loader");
        }
    }

    private void OnDrawGizmos()
    {
        var loader = XRGeneralSettings.Instance?.Manager?.activeLoader;
        if (loader == null)
        {
            Debug.LogWarning("Could not get active Loader.");
            return;
        }
        inputSubsystem = loader.GetLoadedSubsystem<XRInputSubsystem>();
        boundaryPoints = new List<Vector3>();
        if (inputSubsystem.TryGetBoundaryPoints(boundaryPoints))
        {
            // Draw boundary gizmo
            if (boundaryPoints != null && boundaryPoints.Count > 1)
            {
                for (int i = 0; i < boundaryPoints.Count; i++)
                {
                    Gizmos.DrawLine(boundaryPoints[i], boundaryPoints[(i + 1) % boundaryPoints.Count]);
                }
            }
        }
        else
        {
            Debug.LogWarning($"Could not get Boundary Points for Loader");
        }
    }
}
