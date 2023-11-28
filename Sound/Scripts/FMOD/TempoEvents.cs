using FMOD.Studio;
using FMODUnity;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TempoEvents : MonoBehaviour
{
    class TimelineInfo
    {
        private float tempo = 120;
        public void SetTempo(float value) => tempo = value;
        public float Tempo => tempo;
    }

    TimelineInfo timelineInfo;
    GCHandle timelineHandle;


    [SerializeField]
    private StudioEventEmitter musicEmitter;
    private EVENT_CALLBACK callback;

    FMOD.Studio.EventInstance musicInstance;

    private int timelinePosInt;
    private float timelinePos;
    private float beatLength;

    // Start is called before the first frame update
    void Start()
    {
        timelineInfo = new TimelineInfo();
        callback = new EVENT_CALLBACK(TempoMarkerCallback);
        musicEmitter.Play();
        musicInstance = musicEmitter.EventInstance;

        // Pin the class that will store the data modified during the callback
        timelineHandle = GCHandle.Alloc(timelineInfo);
        // Pass the object through the userdata of the instance
        musicInstance.setUserData(GCHandle.ToIntPtr(timelineHandle));

        musicInstance.setCallback(callback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
    }

    public float GetBeatOffset()
    {
        musicEmitter.EventInstance.getTimelinePosition(out timelinePosInt);
        timelinePos = (float)timelinePosInt / 100;
        beatLength = 60f / timelineInfo.Tempo;
        float timeSinceLastBeat = timelinePos % beatLength;
        float timeUntilNextBeat = beatLength - timeSinceLastBeat;
        if (timeSinceLastBeat < timeUntilNextBeat)
        {
            Debug.Log($"{timeSinceLastBeat} late");
            return timeSinceLastBeat;
        }
        else
        {
            Debug.Log($"{timeUntilNextBeat} early");
            return timeUntilNextBeat;
        }
    }

    [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
    static FMOD.RESULT TempoMarkerCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
    {
        FMOD.Studio.EventInstance instance = new FMOD.Studio.EventInstance(instancePtr);

        // Retrieve the user data
        IntPtr timelineInfoPtr;
        FMOD.RESULT result = instance.getUserData(out timelineInfoPtr);
        if (result != FMOD.RESULT.OK)
        {
            Debug.LogError("Timeline Callback error: " + result);
        }
        else if (timelineInfoPtr != IntPtr.Zero)
        {
            // Get the object to store beat and marker details
            GCHandle timelineHandle = GCHandle.FromIntPtr(timelineInfoPtr);
            TimelineInfo timelineInfo = (TimelineInfo)timelineHandle.Target;

            switch (type)
            {


                case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT:
                    {
                        var parameter = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
                        timelineInfo.SetTempo(parameter.tempo);
                        break;
                    }
                case FMOD.Studio.EVENT_CALLBACK_TYPE.DESTROYED:
                    {
                        // Now the event has been destroyed, unpin the timeline memory so it can be garbage collected
                        timelineHandle.Free();
                        break;
                    }
            }
        }
        return FMOD.RESULT.OK;
    }
}
