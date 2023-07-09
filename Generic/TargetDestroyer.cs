using UnityEngine;

public class TargetDestroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private void Start()
    {
        if (target == null)
        {
            target = this.gameObject;
        }
    }

    public void DestroyTarget()
    {
        Destroy(target);
    }

}
