using System;
using UnityEngine;

namespace HoochLib.Generic
{
    public class EventTrigger_OnCountChanged : EventTrigger
    {
        [SerializeField]
        private Counter counter;

        [SerializeField]
        private int target;
        [SerializeField]
        private bool onlyTriggerOnTarget = true;

        // Use this for initialization
        void Start()
        {
            counter.CountChanged += OnCountChanged;
        }

        private void OnCountChanged(object sender, EventArgs e)
        {
            if (counter.Count == target || !onlyTriggerOnTarget)
            {
                InvokeEvents();
            }
        }

    }
}