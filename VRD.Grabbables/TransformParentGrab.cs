using UnityEngine;


public class TransformParentGrab : MonoBehaviour
{
    [SerializeField]
    GrabInteractorOverlapSphere interactor;
    [SerializeField]
    private bool restoreParentOnDrop = false;

    private Transform originalParent;

    public void ReparentTransform(Transform parent)
    {
        Transform target = interactor.CurrentInteractable.gameObject.transform;
        target.SetParent(parent, false);
        target.localPosition = Vector3.zero;
        target.localRotation = Quaternion.identity;
    }

    public void UnparentTransform()
    {
        if (restoreParentOnDrop)
        {
            interactor.CurrentInteractable.gameObject.transform.parent = originalParent;
        }
        else
        {
            interactor.CurrentInteractable.gameObject.transform.parent = null;
        }
    }
}
