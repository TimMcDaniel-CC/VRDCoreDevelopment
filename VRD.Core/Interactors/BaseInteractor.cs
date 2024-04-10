using UnityEngine;

public class BaseInteractor : MonoBehaviour
{
    protected IInteractable currentInteractable;
    public IInteractable CurrentInteractable
    {
        get => currentInteractable;
    }
}
