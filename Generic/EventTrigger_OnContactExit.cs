using UnityEngine;
using UnityEngine.Events;

namespace Assets.Modules.GameJamHelpers.Generic
{
    public class EventTrigger_OnContactExit : MonoBehaviour
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
        public void SetActive(bool active) => this.active = active;


        private void OnCollisionExit2D(Collision2D collision)
        {
            if (onCollision && active)
            {
                if (((1 << collision.gameObject.layer) & contactItems.value) != 0)
                {
                    events.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (onTrigger && active)
            {
                if (((1 << collision.gameObject.layer) & contactItems.value) != 0)
                {
                    events.Invoke();
                }
            }
        }
    }
}