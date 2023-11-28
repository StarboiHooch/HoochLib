using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BeatCallbackEmitter : MonoBehaviour
{
    [Serializable]
    class TimelineInfo
    {
        public int CurrentMusicBeat = 0;
    }

    [SerializeField]
    TimelineInfo timelineInfo;
    GCHandle timelineHandle;

    [SerializeField]
    private FMODUnity.EventReference MusicEventName;

    private FMOD.Studio.EventInstance musicInstance;

    private FMOD.Studio.EVENT_CALLBACK beatCallback;


    public static event EventHandler<BeatEventArgs> BeatEvent;

    //private void HandleBeatEvent(object sender, BeatEventArgs e)
    //{
    //    Debug.Log($"Beat {e.Beat}!");
    //}

    void Start()
    {
        timelineInfo = new TimelineInfo();

        // Explicitly create the delegate object and assign it to a member so it doesn't get freed
        // by the garbage collected while it's being used
        beatCallback = new FMOD.Studio.EVENT_CALLBACK(BeatEventCallback);

        musicInstance = FMODUnity.RuntimeManager.CreateInstance(MusicEventName);

        // Pin the class that will store the data modified during the callback
        timelineHandle = GCHandle.Alloc(timelineInfo);
        // Pass the object through the userdata of the instance
        musicInstance.setUserData(GCHandle.ToIntPtr(timelineHandle));

        musicInstance.setCallback(beatCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
        musicInstance.start();
    }

    void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicInstance.release();
    }


    [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
    static FMOD.RESULT BeatEventCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
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
                        var parameters = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
                        timelineInfo.CurrentMusicBeat = parameters.beat;
                        BeatEvent?.Invoke(null, new BeatEventArgs(parameters.beat));
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






//public class BeatCallbackEmitterOLD : MonoBehaviour
//{

//    [SerializeField]
//    private TimelineInfo timelineInfo;
//    private GCHandle timelineHandle;

//    public FMODUnity.EventReference EventName;


//    public event EventHandler<BeatEventArgs> BeatEvent;

//    private void HandleBeatEvent(object sender, BeatEventArgs e)
//    {
//        Debug.Log($"Beat {e.Beat}!");
//    }

//    [SerializeField]
//    private StudioEventEmitter musicEmitter;
//    private EVENT_CALLBACK callback;

//    FMOD.Studio.EventInstance musicInstance;

//    // Start is called before the first frame update
//    void Start()
//    {
//        BeatEvent += HandleBeatEvent;
//        Debug.Log("Test");

//        timelineInfo = new TimelineInfo();
//        callback = new EVENT_CALLBACK(BeatEventCallback);

//        musicEmitter.Play();
//        musicInstance = musicEmitter.EventInstance;

//        // Pin the class that will store the data modified during the callback
//        timelineHandle = GCHandle.Alloc(timelineInfo);
//        // Pass the object through the userdata of the instance
//        musicInstance.setUserData(GCHandle.ToIntPtr(timelineHandle));

//        musicInstance.setCallback(callback, EVENT_CALLBACK_TYPE.TIMELINE_BEAT | EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
//        musicInstance.start();
//    }


//    [AOT.MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
//    static FMOD.RESULT BeatEventCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
//    {
//        EventInstance instance = new EventInstance(instancePtr);
//        // Retrieve the user data
//        IntPtr timelineInfoPtr;
//        FMOD.RESULT result = instance.getUserData(out timelineInfoPtr);
//        if (result != FMOD.RESULT.OK)
//        {
//            Debug.LogError("Timeline Callback error: " + result);
//        }
//        else if (timelineInfoPtr != IntPtr.Zero)
//        {
//            // Get the object to store beat and marker details
//            GCHandle timelineHandle = GCHandle.FromIntPtr(timelineInfoPtr);
//            TimelineInfo timelineInfo = (TimelineInfo)timelineHandle.Target;

//            switch (type)
//            {


//                case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT:
//                    {
//                        var parameters = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
//                        timelineInfo.SetTempo(parameters.tempo);
//                        // BeatEvent(null, new BeatEventArgs(parameters.beat));
//                        break;
//                    }
//                case FMOD.Studio.EVENT_CALLBACK_TYPE.DESTROYED:
//                    {
//                        // Now the event has been destroyed, unpin the timeline memory so it can be garbage collected
//                        timelineHandle.Free();
//                        break;
//                    }
//            }
//        }
//        return FMOD.RESULT.OK;
//    }
//}
