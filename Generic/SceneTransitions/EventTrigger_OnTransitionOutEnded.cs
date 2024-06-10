using System;
using UnityEngine;

namespace HoochLib.Generic.SceneTransitions
{
    public class EventTrigger_OnTransitionOutEnded : EventTrigger
    {
        [SerializeField] private SceneTransition transition;
        private void Start()
        {
            transition.OnTransitionOutEnded += HandleOnTransitionOutEnded;
        }

        private void OnDestroy()
        {
            transition.OnTransitionOutEnded -= HandleOnTransitionOutEnded;
        }

        private void HandleOnTransitionOutEnded(object sender, EventArgs e)
        {
            InvokeEvents();
        }
    }
}