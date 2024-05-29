using System;

namespace HoochLib.Generic
{
    public class EventTrigger_OnStart : EventTrigger
    {
        private void Start()
        {
            InvokeEvents();
        }
    }
}