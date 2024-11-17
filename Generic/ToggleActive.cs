using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    public void Toggle()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    public void SetState(bool value)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(value);
        }
    }
}
