using System;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    [SerializeField] private SoundLibrary soundLibrary;
    [SerializeField] private AudioSource oneShotSource;
    [SerializeField] private SaveData saveData;
    private string SAVE_DATA_VOLUME_KEY = "sfxVolume";

    private void Start()
    {
        if (saveData.HasKey(SAVE_DATA_VOLUME_KEY))
        {
            var volume = saveData.GetValue<float>(SAVE_DATA_VOLUME_KEY);
            SetVolume(volume);
        }
    }

    public void SetVolume(float vol)
    {
        oneShotSource.volume = vol;
    }

    public void PlaySound(string sound)
    {
        AudioClip clip = soundLibrary.GetSound(sound);
        oneShotSource.PlayOneShot(clip);
    }
}