using UnityEngine;

public interface IInteractable
{
    public GameObject gameObject { get;}
    public void StartInteraction();
    public void StopInteraction();
}
