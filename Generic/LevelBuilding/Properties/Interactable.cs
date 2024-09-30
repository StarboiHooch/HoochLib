using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string description;

    [SerializeField] private bool active = true;
    public string Description => description;

    [SerializeField]
    private UnityEvent onInteract;

    public void SetActive(bool active) => this.active = active;
    public void Interact()
    {
        if (active)
        {
            onInteract?.Invoke();
        }
    }
}
