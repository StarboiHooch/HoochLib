using System;
using System.Runtime.InteropServices;
using FMOD;
using FMOD.Studio;
using Debug = UnityEngine.Debug;

[Serializable]
public class BeatCallbackEmitter
{
    private EVENT_CALLBACK handleCallbacks = HandleCallbacks;

    private string eventPath;
    public static event EventHandler<BeatEventArgs> OnAnyBeat;
    public event EventHandler<BeatEventArgs> OnBeat;
    public static event EventHandler<string> OnAnyStopped;
    public event EventHandler<string> OnStopped;

    public void StartInstanceWithBeatCallback(EventInstance musicInstance)
    {
        musicInstance.getDescription(out var desc);
        desc.getPath(out eventPath);

        var beatResult = musicInstance.setCallback(handleCallbacks, EVENT_CALLBACK_TYPE.TIMELINE_BEAT | EVENT_CALLBACK_TYPE.STOPPED );
        if (beatResult != RESULT.OK) Debug.LogError("Something went wrong with setting up FMOD beat callbacks");

        OnAnyBeat += HandleOnAnyBeat;
        OnAnyStopped += HandleOnAnyStopped;

        musicInstance.start();
    }

    public void OnDisable()
    {
        OnAnyBeat -= HandleOnAnyBeat;
        OnAnyStopped -= HandleOnAnyStopped;
    }

    private void HandleOnAnyBeat(object sender, BeatEventArgs e)
    {
        if (e.EventPath == eventPath) OnBeat?.Invoke(sender, e);
    }
    private void HandleOnAnyStopped(object sender, string path)
    {
        if (path == this.eventPath) OnStopped?.Invoke(sender, path);
    }


    private static RESULT HandleCallbacks(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
    {
        var instance = new EventInstance(instancePtr);

        instance.getDescription(out var desc);
        desc.getPath(out var callbackEventPath);

        switch (type)
        {
            case EVENT_CALLBACK_TYPE.STOPPED:
                OnAnyStopped?.Invoke(null, callbackEventPath);
                break;
            case EVENT_CALLBACK_TYPE.TIMELINE_BEAT:
                var parameters =
                    (TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(TIMELINE_BEAT_PROPERTIES));
                OnAnyBeat?.Invoke(null, new BeatEventArgs(parameters.beat, parameters.bar, callbackEventPath));
                break;
            default:
                break;
        }
        
        return RESULT.OK;
    }
}