using System.Collections;
using System.Collections.Generic;
using HoochLib.Generic;
using UnityEngine;

public class EventTrigger_OnEnable : EventTrigger
{
    private void OnEnable()
    {
        InvokeEvents();
    }
}
