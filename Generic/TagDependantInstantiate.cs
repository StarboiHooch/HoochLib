using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagDependantInstantiate : MonoBehaviour
{
    [SerializeField] private string tag = "Music";
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.FindGameObjectWithTag(tag);
        if (go == null)
        {
            Instantiate(prefab);
        }
    }

    void Update()
    {
        
    }
}
