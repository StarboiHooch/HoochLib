using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField]
    private CameraUtility cam;

    [SerializeField]
    private CameraShakeValues shakeValues;

    public void Shake()
    {
        cam.RequestCameraShake(shakeValues);
    }
}
