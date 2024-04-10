using UnityEngine;

public class BodyPresence : MonoBehaviour
{
    [SerializeField]
    protected SphereCollider head;
    [SerializeField]
    protected CapsuleCollider body;
    [SerializeField]
    protected float headClearanceThreshold = 0.04f;

    public float BodyHeight
    {
        get => body.height;
    }
    


    protected virtual void FixedUpdate()
    {
        AlignHeadToCamera();
        AlignBodyToCamera();
        ResizeBody();
    }
    protected virtual void AlignHeadToCamera()
    {
        head.transform.position = Camera.main.transform.position;
        head.transform.rotation = Quaternion.Euler(new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f));
    }

    protected virtual void AlignBodyToCamera()
    {
        body.transform.localPosition = Vector3.zero;
        Vector3 newPostion = new Vector3(head.transform.position.x, body.transform.position.y, head.transform.position.z);
        Quaternion newRotation = Quaternion.Euler(new Vector3(0f, head.transform.eulerAngles.y, 0f));
        body.transform.SetPositionAndRotation(newPostion, newRotation);
    }

    protected virtual void ResizeBody()
    {
        float calculatedHeight = head.transform.localPosition.y - head.radius;
        body.height = calculatedHeight;

        body.center = new Vector3(0f, body.height * 0.5f, 0f);
    }

}
