using UnityEngine;
using UnityEngine.UI;

public class FMODUtility : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private void Start()
    {
        if (slider != null)
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                slider.value = PlayerPrefs.GetFloat("Volume");
            }
        }
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        FMODUnity.StudioEventEmitter studioEventEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
        studioEventEmitter.EventInstance.setVolume(volume);
    }
}
