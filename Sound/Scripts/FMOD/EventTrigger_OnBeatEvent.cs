using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HoochLib.Sound.Scripts.FMOD
{
    [Serializable]
    public class Bar
    {
        public List<int> Beats;
    }
    public class EventTrigger_OnBeatEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent events = new UnityEvent();

        [SerializeField]
        private List<Bar> ActiveBeats;
        private int currentBarIndex = 0;

        private bool firstBar = true;

        [SerializeField]
        private bool active = true;
        public void SetActive(bool active) => this.active = active;

        private void Start()
        {
            firstBar = true;
            currentBarIndex = 0;
            BeatCallbackEmitter.BeatEvent += HandleBeatEvent;
        }

        private void OnDestroy()
        {
            BeatCallbackEmitter.BeatEvent -= HandleBeatEvent;
        }
        private void HandleBeatEvent(object sender, BeatEventArgs e)
        {
            if (active)
            {
                if (e.Beat == 1)
                {
                    if (firstBar)
                    {
                        firstBar = false;
                    }
                    else
                    {
                        if (currentBarIndex < ActiveBeats.Count - 1)
                        {
                            currentBarIndex++;
                        }
                        else
                        {
                            currentBarIndex = 0;
                        }
                    }
                }
                if (ActiveBeats[currentBarIndex].Beats.Contains(e.Beat))
                {
                    events.Invoke();
                }
            }
        }

    }
}