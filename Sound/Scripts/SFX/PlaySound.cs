using System;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private string sound;

    private void Start()
    {
        if (soundManager == null) soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void PlayOneShot()
    {
        if(soundManager != null)
            soundManager.PlaySound(sound);
    }
}