using UnityEngine;
using UnityEngine.UI;

public class FMODUtility : MonoBehaviour
{
    [SerializeField]
    private SaveData saveData;
    [SerializeField]
    private string key;
    [SerializeField]
    private bool mute;

    FMODUnity.StudioEventEmitter studioEventEmitter;

    private void Start()
    {
        studioEventEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
        if (saveData.HasKey(key))
        {
            SetVolume(saveData.GetValue<float>(key));
        }
        if (mute)
        {
            studioEventEmitter.EventInstance.setVolume(0f);
        }
    }
    public void SetVolume(float volume, bool saveValue = false)
    {
        studioEventEmitter.EventInstance.setVolume(volume);
    }

    public void SetParameter(string name, float value)
    {
        studioEventEmitter.SetParameter(name, value);
    }

}
