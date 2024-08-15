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
        var volume = saveData.GetValue<float>(SAVE_DATA_VOLUME_KEY);
        SetVolume(volume);
    }

    private void SetVolume(float vol)
    {
        saveData.SaveValue(SAVE_DATA_VOLUME_KEY, vol);
        oneShotSource.volume = vol;
    }

    public void PlaySound(string sound)
    {
        AudioClip clip = soundLibrary.GetSound(sound);
        oneShotSource.PlayOneShot(clip, 1f);
    }
}