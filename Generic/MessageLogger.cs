using System.Collections.Generic;
using UnityEngine;

public class MessageLogger : MonoBehaviour
{
    [SerializeField]
    private List<string> messages;

    public void LogMessage()
    {
        Debug.Log("Testing 123");
    }

    public void LogMessage(int index)
    {
        if (index < 0 || index >= messages.Count)
        {
            Debug.LogError("invalid index for LogMessage");
        }
        else
        {
            Debug.Log(messages[index]);
        }
    }
}
