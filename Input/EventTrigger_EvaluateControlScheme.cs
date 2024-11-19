using System.Collections;
using System.Collections.Generic;
using HoochLib.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventTrigger_EvaluateControlScheme : EventTrigger
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private bool invokeOnKeyboard;
    [SerializeField] private bool invokeOnGamepad;

    public void EvaluateControlSchemeAndInvoke()
    {
        var controlScheme = GetControlScheme();
        if(controlScheme == "Keyboard" && invokeOnKeyboard) InvokeEvents();
        if(controlScheme == "Gamepad" && invokeOnGamepad) InvokeEvents();
    }
    
    private string GetControlScheme()
    {
        var controlScheme = playerInput.currentControlScheme;
        return controlScheme;
    }
}
