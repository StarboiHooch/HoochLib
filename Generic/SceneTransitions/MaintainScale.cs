using UnityEngine;

public class MaintainScale : MonoBehaviour
{
    [SerializeField]
    private RectTransform parentRect;
    [SerializeField]
    private RectTransform thisRect;

    [SerializeField]
    private Vector3 initialScale;

    [SerializeField]
    private Vector3 initialParentScale;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (parentRect.localScale.x != 0 && parentRect.localScale.y != 0 && parentRect.localScale.z != 0)
        {
            thisRect.localScale = new Vector3(initialScale.x / (parentRect.localScale.x / initialParentScale.x),
                                           initialScale.y / (parentRect.localScale.y / initialParentScale.y),
                                           initialScale.z / (parentRect.localScale.z / initialParentScale.z));
        }
    }
}
