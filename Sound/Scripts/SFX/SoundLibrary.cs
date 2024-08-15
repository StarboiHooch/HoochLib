using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "HoochLib/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
    [SerializeField] private List<SoundEffect> soundEffects;

    public AudioClip GetSound(string soundName)
    {
        var matchingSound = soundEffects.FirstOrDefault(s => s.Name == soundName);
        if (matchingSound != null)
            return matchingSound.Clip;

        throw new ArgumentException($"{soundName} not found in SoundLibrary");
    }
}