using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SoundEffect
{
    [SerializeField] private string name;
    [SerializeField] private AudioClip defaultClip;
    [SerializeField] private List<AudioClip> randomClips;

    public string Name => name;
    public AudioClip Clip => randomClips.Count > 0 ? randomClips[Random.Range(0, randomClips.Count)] : defaultClip;
}