using UnityEngine;

namespace GameJamHelpers.Generic
{
    public class EventTrigger_OnContactExit : EventTrigger
    {

        [SerializeField]
        private bool onCollision = true;
        [SerializeField]
        private bool onTrigger = true;

        [SerializeField]
        private LayerMask contactItems;

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (onCollision && active)
            {
                if (((1 << collision.gameObject.layer) & contactItems.value) != 0)
                {
                    InvokeEvents();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (onTrigger && active)
            {
                if (((1 << collision.gameObject.layer) & contactItems.value) != 0)
                {
                    InvokeEvents();
                }
            }
        }
    }
}