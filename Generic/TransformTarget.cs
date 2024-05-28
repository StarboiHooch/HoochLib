using UnityEngine;

public class TransformTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    public void SetTargetPosition(Transform position)
    {
        target.transform.position = position.position;
    }
}
