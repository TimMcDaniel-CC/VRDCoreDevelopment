using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using VRD.Input;

[AddComponentMenu("VRD/Interactors/Grab Interactor (Physics Optimized)")]
public class GrabInteractorOverlapSphere : BaseInteractor
{
    [SerializeField]
    private float interactionRadius = 0.1f;

    private Collider[] results = new Collider[1];

    [SerializeField]
    private UnityEvent onGrab;
    [SerializeField]
    private UnityEvent onRelease;

    public void GrabObject()
    {
        if(currentInteractable != null)
        {
            return;
        }

        Physics.OverlapSphereNonAlloc(this.transform.position, interactionRadius, results);
        SetCurrentInteractable(results);
        if(currentInteractable == null) 
        { 
            return; 
        }
        

        onGrab?.Invoke();

        currentInteractable.StartInteraction();
    }

    public void ReleaseObject()
    {
        if (currentInteractable == null)
        {
            return;
        }
        currentInteractable.gameObject.transform.parent = null;        

        currentInteractable.StopInteraction();
        onRelease?.Invoke();
        currentInteractable = null;
    }

    private void SetCurrentInteractable(Collider[] colliders)
    {
        for(int i=0; i<results.Length; i++)
        {
            IInteractable interactable = colliders[i].GetComponent<IInteractable>();
            if(interactable != null)
            {
                currentInteractable = interactable;
                results = new Collider[1];
                return;
            }
        }
        currentInteractable = null; 
    }

    private void OnDrawGizmos()
    {
        Color startColor = Gizmos.color;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, interactionRadius);
        Gizmos.color = startColor;
    }

}
