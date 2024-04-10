using UnityEngine;
using UnityEngine.Events;

public class SimpleInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent onStartInteraction;
    [SerializeField]
    private UnityEvent onStopInteraction;
    GameObject IInteractable.gameObject 
    { 
        get => this.gameObject;
    }

    public void StartInteraction()
    {
        Debug.Log("Start Interaction " + gameObject.name);
        onStartInteraction?.Invoke();
    }

    public void StopInteraction()
    {
        onStopInteraction?.Invoke();
    }
}
