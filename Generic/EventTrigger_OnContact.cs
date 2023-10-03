using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger_OnContact : MonoBehaviour
{
    [SerializeField]
    private UnityEvent events = new UnityEvent();

    [SerializeField]
    private bool onCollision = true;
    [SerializeField]
    private bool onTrigger = true;

    [SerializeField]
    private LayerMask contactItems;

    [SerializeField]
    private bool active = true;
    [SerializeField]
    private float delay = 0f;
    public void SetActive(bool active) => this.active = active;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onCollision && active)
        {
            InvokeEvents(collision.collider);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTrigger && active)
        {
            InvokeEvents(collision);
        }
    }

    private void InvokeEvents(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & contactItems.value) != 0)
        {
            if (delay != 0)
            {
                StartCoroutine(Delay(delay));
            }
            else
            {
                events.Invoke();
            }
        }
    }
    IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);
        events.Invoke();
    }

}
