using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameJamHelpers.Generic
{
    public abstract class EventTrigger : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent events = new UnityEvent();

        [SerializeField]
        protected bool active = true;
        [SerializeField]
        protected float delay = 0f;
        public void SetActive(bool active) => this.active = active;

        public void InvokeEvents()
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

        IEnumerator Delay(float duration)
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