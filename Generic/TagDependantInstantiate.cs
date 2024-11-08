using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TagDependantInstantiate : MonoBehaviour
{
    [SerializeField] private string tagName = "Music";
    [SerializeField] private GameObject prefab;

    [SerializeField] private UnityEvent afterInstantiate;
    [SerializeField] private UnityEvent afterNotInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.FindGameObjectWithTag(tagName);
        if (go == null)
        {
            Instantiate(prefab);
            afterInstantiate.Invoke();
        }
        else
        {
            afterNotInstantiate.Invoke();
        }
    }
}
