using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace HoochLib.Generic
{
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField] protected UnityEvent events = new();

        [SerializeField] protected bool active = true;

        [SerializeField] protected float delay;

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public void AddAction(UnityAction action)
        {
            events.AddListener(action);
        }

        public void InvokeEvents()
        {
            if (active)
            {
                if (delay != 0)
                    StartCoroutine(InvokeEventsAfterDelay(delay));
                else
                    events.Invoke();
            }
        }

        protected void InvokeEvents(UnityEvent unityEvent)
        {
            if (!active) return;
            if (delay != 0)
                StartCoroutine(InvokeEventsAfterDelay(delay));
            else
                unityEvent.Invoke();
        }

        protected void InvokeEvents<T>(UnityEvent<T> unityEvent, T value)
        {
            if (!active) return;
            if (delay != 0)
                StartCoroutine(InvokeEventsAfterDelay(delay));
            else
                unityEvent.Invoke(value);
        }

        private IEnumerator InvokeEventsAfterDelay(float duration)
        {
            yield return new WaitForSeconds(duration);
            events.Invoke();
        }

        public void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }
}