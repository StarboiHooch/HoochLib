using UnityEngine;

public class MessageLogger : MonoBehaviour
{
    [SerializeField]
    private string message;

    public void LogMessage()
    {
        Debug.Log(message);
    }
}
