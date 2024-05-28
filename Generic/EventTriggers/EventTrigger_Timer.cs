﻿using System.Collections;
using UnityEngine;

namespace HoochLib.Generic
{
    public class EventTrigger_Timer : EventTrigger
    {

        [SerializeField]
        private float time = 1f;

        [SerializeField]
        private bool playOnStart = false;
        private bool coroutineActive = false;

        private void Start()
        {
            coroutineActive = false;
            if (playOnStart)
            {
                StartCoroutine(PlayCoroutine());
            }
        }

        public void Play()
        {
            StartCoroutine(PlayCoroutine());
        }

        public IEnumerator PlayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            events.Invoke();
            StartCoroutine(StartTimer());
        }

        IEnumerator StartTimer()
        {
            if (!coroutineActive)
            {
                coroutineActive = true;
                yield return new WaitForSeconds(time);
                events.Invoke();
                coroutineActive = false;
                StartCoroutine(StartTimer());
            }
        }
    }
}