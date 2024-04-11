using UnityEngine;

public class BodyAwarenessRaycaster : MonoBehaviour
{
    [Header("Body Measurement Settings")]
    [SerializeField]
    private float bodyHeight = 2f;
    private Transform camTransform;

    [Header("Upward Raycast Settings")]
    [SerializeField]
    private float headClearanceThreshold = 0.05f;
    [SerializeField]
    private LayerMask UpwardLayerMask;

    [Header("Sideways Raycast Settings")]
    [SerializeField]
    private float sideRaycastThreshold = 1.0f;
    [SerializeField]
    private bool fixedHorizontalAlignment = false;
    [SerializeField]
    private LayerMask RightSideLayerMask;
    [SerializeField]
    private LayerMask LeftSideLayerMask;

    [Header("Downward Raycast Settings")]
    [SerializeField]
    private float downwardRaycastThreshold = 1.0f;
    
    [SerializeField]
    private LayerMask DownwardLayerMask;
    
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
        Vector3 right = fixedHorizontalAlignment ? new Vector3(camTransform.right.x, 0f, 0f) : camTransform.right;
        downwardHit = Physics.Raycast(bodyCenter, Vector3.down, out downwardHitInfo, ((bodyHeight / 2) + downwardRaycastThreshold));
        rightSideHit = Physics.Raycast(bodyCenter, right, out rightSideHitInfo, sideRaycastThreshold);
        leftSideHit = Physics.Raycast(bodyCenter, -right, out leftSideHitInfo, sideRaycastThreshold);
    }
    protected Vector3 GetBodyCenter()
    {
        return new Vector3(camTransform.position.x, 
                            camTransform.position.y - (bodyHeight / 2), 
                            camTransform.position.z);
    }
    protected virtual void OnDrawGizmos()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }
        
        
        Vector3 right = fixedHorizontalAlignment ? new Vector3(camTransform.right.x, 0f, 0f) : camTransform.right;
        
        Vector3 bodyCenter = GetBodyCenter();


        Debug.DrawRay(camTransform.position, Vector3.up * (headClearanceThreshold), Color.red);
        Debug.DrawRay(bodyCenter, Vector3.down * ((bodyHeight / 2) + downwardRaycastThreshold), Color.blue);
        Debug.DrawRay(bodyCenter, right * sideRaycastThreshold, Color.blue);        
        Debug.DrawRay(bodyCenter, -right * sideRaycastThreshold, Color.red);
    }
}
