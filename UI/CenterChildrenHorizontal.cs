using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CenterChildrenHorizontal : MonoBehaviour
{
    [SerializeField] private float padding = 20f;
    
    [SerializeField] private List<RectTransform> elements;
    [SerializeField] private int previousCount = 0;
    
    private void OnValidate()
    {
        GetElements();
    }

    public void GetElements()
    {
        var allChildren = gameObject.GetComponentsInChildren<Transform>();
        var directChildren = allChildren.Where(go => go.parent.gameObject == gameObject);
        elements = directChildren.Select(e => e.gameObject.GetComponent<RectTransform>()).ToList();
        
        if (elements.Count != previousCount)
        {
            Center();
            previousCount = elements.Count;
        }
    }
    
    public void Center()
    {
        if (elements.Count == 0) return;
        
        float totalWidth = elements.Select(e => e.sizeDelta.x).Sum() + padding * (elements.Count - 1);

        float nextX = -totalWidth/2;
        foreach (var element in elements)
        {
            element.pivot = new Vector2(0, element.pivot.y);
            element.localPosition = new Vector3(nextX, element.localPosition.y, element.localPosition.z);
            nextX += padding + element.sizeDelta.x;
        }
    }
}
