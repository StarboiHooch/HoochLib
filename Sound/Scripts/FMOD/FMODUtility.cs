using UnityEngine;
using UnityEngine.UI;

public class FMODUtility : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private bool mute;

    FMODUnity.StudioEventEmitter studioEventEmitter;

    private void Start()
    {
        studioEventEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
        if (slider != null)
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                slider.value = PlayerPrefs.GetFloat("Volume");
            }
        }
        if (mute)
        {
            studioEventEmitter.EventInstance.setVolume(0f);
        }
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        studioEventEmitter.EventInstance.setVolume(volume);
    }

    public void SetParameter(string name, float value)
    {
        studioEventEmitter.SetParameter(name, value);
    }

}
