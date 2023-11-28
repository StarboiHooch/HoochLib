using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Modules.GameJamHelpers.Generic
{
    public class EventTrigger_Timer : MonoBehaviour
    {

        [SerializeField]
        private UnityEvent events = new UnityEvent();

        [SerializeField]
        private float time = 1f;
        [SerializeField]
        private bool repeat = true;

        [SerializeField]
        private bool playOnStart = false;
        private bool coroutineActive = false;

        private void Start()
        {
            if (playOnStart)
            {
                Play();
            }
        }

        public void Play()
        {
            if (!coroutineActive)
            {
                StartCoroutine(InvokeAfterDelay());
            }
        }

        IEnumerator InvokeAfterDelay()
        {
            coroutineActive = true;
            yield return new WaitForSeconds(time);
            events.Invoke();
            if (repeat)
            {
                StartCoroutine(InvokeAfterDelay());
            }
            coroutineActive = false;
        }
    }
}