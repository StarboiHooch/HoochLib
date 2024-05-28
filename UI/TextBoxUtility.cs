using UnityEngine;

public class TextBoxUtility : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI tmpro;
    private void Awake()
    {
        tmpro = GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void SetText(string text)
    {
        tmpro.text = text;
    }
    public void SetText(int text)
    {
        tmpro.text = text.ToString();
    }

}
