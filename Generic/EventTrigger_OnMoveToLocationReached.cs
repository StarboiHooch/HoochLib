using PlatformingScripts;
using System;
using UnityEngine;

namespace GameJamHelpers.Generic
{
    public class EventTrigger_OnMoveToLocationReached : EventTrigger
    {
        private PlatformingController player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformingController>();
            player.MoveToLocationReached += OnMoveToLocationReached;
        }

        private void OnDestroy()
        {
            player.MoveToLocationReached -= OnMoveToLocationReached;
        }

        private void OnMoveToLocationReached(object sender, EventArgs e)
        {
            if (active)
            {
                InvokeEvents();
            }
        }
    }
}