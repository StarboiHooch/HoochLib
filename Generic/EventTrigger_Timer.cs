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

        private float timer = 0f;


        private void Update()
        {
            if (timer >= time)
            {
                events.Invoke();
            }
            timer += Time.deltaTime;
        }
    }
}