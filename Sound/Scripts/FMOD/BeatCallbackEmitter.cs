using System;
using System.Runtime.InteropServices;
using FMOD;
using FMOD.Studio;
using Debug = UnityEngine.Debug;

[Serializable]
public class BeatCallbackEmitter
{
    private EVENT_CALLBACK beatCallback = BeatEventCallback;

    private string eventPath;
    public static event EventHandler<BeatEventArgs> OnAnyBeat;
    public event EventHandler<BeatEventArgs> OnBeat;

    public void StartInstanceWithBeatCallback(EventInstance musicInstance)
    {
        musicInstance.getDescription(out var desc);
        desc.getPath(out eventPath);

        var result = musicInstance.setCallback(beatCallback, EVENT_CALLBACK_TYPE.TIMELINE_BEAT);
        if (result != RESULT.OK) Debug.LogError("Something went wrong with setting up FMOD beat callbacks");

        OnAnyBeat += HandleOnAnyBeat;

        musicInstance.start();
    }

    public void OnDisable()
    {
        OnAnyBeat -= HandleOnAnyBeat;
    }

    private void HandleOnAnyBeat(object sender, BeatEventArgs e)
    {
        if (e.EventPath == eventPath) OnBeat?.Invoke(sender, e);
    }


    private static RESULT BeatEventCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
    {
        var instance = new EventInstance(instancePtr);

        instance.getDescription(out var desc);
        desc.getPath(out var callbackEventPath);

        var parameters =
            (TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(TIMELINE_BEAT_PROPERTIES));

        OnAnyBeat?.Invoke(null, new BeatEventArgs(parameters.beat, parameters.bar, callbackEventPath));
        return RESULT.OK;
    }
}