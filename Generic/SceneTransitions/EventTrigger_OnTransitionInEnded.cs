using System;
using UnityEngine;

namespace HoochLib.Generic.SceneTransitions
{
    public class EventTrigger_OnTransitionInEnded: EventTrigger
    {
        [SerializeField] private SceneTransition transition;
        private void Start()
        {
            transition.OnTransitionInEnded += HandleOnTransitionInEnded;
        }

        private void OnDestroy()
        {
            transition.OnTransitionInEnded -= HandleOnTransitionInEnded;
        }

        private void HandleOnTransitionInEnded(object sender, EventArgs e)
        {
            InvokeEvents();
        }
    }
}