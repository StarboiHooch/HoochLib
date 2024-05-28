using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string description;
    public string Description => description;

    [SerializeField]
    private UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }
}
