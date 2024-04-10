using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAwarenessRaycaster : MonoBehaviour
{
    private Transform camTransform;
    [SerializeField]
    private float headClearanceThreshold = 0.05f;
    [SerializeField]
    private float bodyHeight = 2f;
    [SerializeField]
    private LayerMask UpwardLayerMask;
    [SerializeField]
    private LayerMask DownwardLayerMask;
    [SerializeField]
    private LayerMask RightSideLayerMask;
    [SerializeField]
    private LayerMask LeftSideLayerMask;

    RaycastHit upwardHitInfo;
    RaycastHit rightSideHitInfo;
    RaycastHit leftSideHitInfo;
    RaycastHit downwardHitInfo;

    private bool upwardHit = false;
    private bool downwardHit = false;
    private bool rightSideHit = false;
    private bool leftSideHit = false;
    public RaycastHit UpdwardHitInfo
    {
        get => upwardHitInfo;
    }

    public RaycastHit DownwardHitInfo
    { 
        get => downwardHitInfo; 
    }

    public RaycastHit RightSideHitInfo
    {
        get => rightSideHitInfo;
    }

    public RaycastHit LeftSideHitInfo
    {
        get => leftSideHitInfo;
    }



    public float BodyHeight { get => bodyHeight; set => bodyHeight = value; }
    public bool UpwardHit { get => upwardHit; }
    public bool DownwardHit { get => downwardHit; }
    public bool RightSideHit { get => rightSideHit;  }
    public bool LeftSideHit { get => leftSideHit; }

    protected virtual void Reset()
    {
        camTransform = Camera.main.transform;
    }

    protected virtual void Start()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }
    }

    

    protected virtual void Update()
    {
        upwardHit = Physics.Raycast(camTransform.position, Vector3.up, out upwardHitInfo, 0.25f + headClearanceThreshold);

        Vector3 bodyCenter = GetBodyCenter();
        downwardHit = Physics.Raycast(bodyCenter, Vector3.down, out downwardHitInfo, bodyHeight);
        rightSideHit = Physics.Raycast(bodyCenter, camTransform.right, out rightSideHitInfo, 2f);
        leftSideHit = Physics.Raycast(bodyCenter, -camTransform.right, out leftSideHitInfo, 2f);
    }

    protected Vector3 GetBodyCenter()
    {
        return new Vector3(camTransform.position.x, 
                            camTransform.position.y - (bodyHeight / 3), 
                            camTransform.position.z);
    }
    protected virtual void OnDrawGizmos()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }
        Vector3 forward = camTransform.forward;
        forward.x = forward.y = 0f;
        Vector3 right = camTransform.right;

        Vector3 bodyCenter = GetBodyCenter();


        Debug.DrawRay(camTransform.position, Vector3.up * (headClearanceThreshold), Color.red);
        Debug.DrawRay(camTransform.position, (forward * 2f), Color.red);
        Debug.DrawRay(bodyCenter, Vector3.down * 2f, Color.blue);

        Debug.DrawRay(bodyCenter, right * 2f, Color.blue);        
        Debug.DrawRay(bodyCenter, -right * 2f, Color.red);
    }
}
