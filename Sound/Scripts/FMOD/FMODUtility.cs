using FMODUnity;
using UnityEngine;

public class FMODUtility : MonoBehaviour
{
    [SerializeField] private SaveData saveData;

    [SerializeField] private string key;

    [SerializeField] private bool mute;

    private StudioEventEmitter studioEventEmitter;

    public void LoadVolume()
    {
        if (studioEventEmitter == null) studioEventEmitter = GetComponent<StudioEventEmitter>();
        if (saveData.HasKey(key)) SetVolume(saveData.GetValue<float>(key));
        if (mute) studioEventEmitter.EventInstance.setVolume(0f);
    }

    public void SetVolume(float volume)
    {
        studioEventEmitter.EventInstance.setVolume(volume);
    }

    public void SetParameter(string name, float value)
    {
        studioEventEmitter.SetParameter(name, value);
    }
}