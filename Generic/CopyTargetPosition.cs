using UnityEngine;

public class CopyTargetPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position + offset;
    }
}
