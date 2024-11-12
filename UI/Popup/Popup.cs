using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public event EventHandler<EventArgs> OnButton1Pressed;
    public event EventHandler<EventArgs> OnButton2Pressed;
    public event EventHandler<EventArgs> OnPopupClosing;

    [SerializeField] private RectTransform bodyBackground;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private TMP_Text button1Text;
    [SerializeField] private TMP_Text button2Text;

    public void InitializePopup(string body, string button1, string button2)
    {
        bodyText.SetText(body);
        SetBodyBackgroundSize();

        button1Text.SetText(button1);
        button2Text.SetText(button2);
    }

    [ContextMenu("Set Size")]
    private void SetBodyBackgroundSize()
    {
        var textHeight = bodyText.preferredHeight;
        bodyBackground.sizeDelta = new Vector2(bodyBackground.sizeDelta.x, textHeight);
    }

    public void InvokeOnButton1Pressed()
    {
        OnButton1Pressed?.Invoke(this, EventArgs.Empty);
        ClosePopup();
    }
    
    public void InvokeOnButton2Pressed()
    {
        OnButton2Pressed?.Invoke(this, EventArgs.Empty);
        ClosePopup();
    }

    public void ClosePopup()
    {
        OnPopupClosing?.Invoke(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
}
