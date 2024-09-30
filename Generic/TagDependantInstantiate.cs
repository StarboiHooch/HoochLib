using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagDependantInstantiate : MonoBehaviour
{
    [SerializeField] private string tag = "Music";
    [SerializeField] private GameObject prefab;

    [SerializeField] private UnityEvent afterInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.FindGameObjectWithTag(tag);
        if (go == null)
        {
            Instantiate(prefab);
            afterInstantiate.Invoke();
        }
    }

    void Update()
    {
        
    }
}
