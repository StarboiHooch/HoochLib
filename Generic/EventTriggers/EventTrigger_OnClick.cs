using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventTrigger = HoochLib.Generic.EventTrigger;

public class EventTrigger_OnClick : EventTrigger, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        InvokeEvents();
    }
}
