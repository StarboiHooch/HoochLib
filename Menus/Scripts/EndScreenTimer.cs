using UnityEngine;

public class EndScreenTimer : MonoBehaviour
{
    private float time = 0f;
    private bool ended = false;

    [SerializeField]
    private TMPro.TextMeshProUGUI endScreenTimeText;

    [SerializeField]
    private GameObject endScreen;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        ended = false;
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            time += Time.deltaTime;
        }
    }

    public void ShowEndScreen()
    {
        if (!ended)
        {
            endScreen.SetActive(true);
            endScreenTimeText.text = time.ToString("0.00");
            ended = true;
        }
    }




}
