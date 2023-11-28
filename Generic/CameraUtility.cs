using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CameraShakeValues
{
    public float amp;
    public float frq;
    public float time;
    public string name;
    public CameraShakeValues(float amp, float frq, float time = 0f, string name = null)
    {
        this.amp = amp;
        this.frq = frq;
        this.time = time;
        this.name = name;
    }
}
public class CameraUtility : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noiseProfile;
    private float initialAmp;
    private float initialFrq;

    private List<CameraShakeValues> shakeList = new List<CameraShakeValues>();

    // Use this for initialization
    void Start()
    {
        cam = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        noiseProfile = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        initialAmp = noiseProfile.m_AmplitudeGain;
        initialFrq = noiseProfile.m_FrequencyGain;
    }
    public void RequestCameraShake(CameraShakeValues shakeValues)
    {
        if (!shakeList.Contains(shakeValues))
        {
            shakeList.Add(shakeValues);
        }
        if (shakeValues.time != 0)
        {
            StartCoroutine(RemoveFromShakeListAfterWait(shakeValues));
        }
        ApplyMaxShake();
    }
    public void ResetCameraShake()
    {
        noiseProfile.m_AmplitudeGain = initialAmp;
        noiseProfile.m_FrequencyGain = initialFrq;
    }
    public IEnumerator RemoveFromShakeListAfterWait(CameraShakeValues shakeValues)
    {
        yield return new WaitForSeconds(shakeValues.time);
        RemoveFromShakeList(shakeValues);
    }

    public void RemoveFromShakeList(CameraShakeValues shakeValues)
    {
        shakeList.Remove(shakeValues);
        if (shakeList.Count == 0)
        {
            ResetCameraShake();
        }
        else
        {
            ApplyMaxShake();
        }
    }

    public void ApplyMaxShake()
    {
        if (shakeList.Count > 0)
        {
            shakeList.OrderByDescending(s => s.amp);
            noiseProfile.m_AmplitudeGain = shakeList[0].amp;
            noiseProfile.m_FrequencyGain = shakeList[0].frq;
        }
    }
}
