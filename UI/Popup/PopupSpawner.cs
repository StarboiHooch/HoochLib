using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;
    [SerializeField] [TextArea] private string bodyText;
    [SerializeField] private string button1Text;
    [SerializeField] private string button2Text;

    [SerializeField] private UnityEvent button1Actions;
    [SerializeField] private UnityEvent button2Actions;

    private Popup popupInstance;

    public void SpawnPopup()
    {
        popupInstance = Instantiate(popupPrefab).GetComponent<Popup>();
        popupInstance.InitializePopup(bodyText, button1Text, button2Text);
        popupInstance.OnButton1Pressed += onButton1Pressed;
        popupInstance.OnButton2Pressed += onButton2Pressed;
        popupInstance.OnPopupClosing += onPopupClosing;
    }

    private void onButton1Pressed(object sender, EventArgs e)
    {
        button1Actions.Invoke();
    }
    private void onButton2Pressed(object sender, EventArgs e)
    {
        button2Actions.Invoke();
    }
    private void onPopupClosing(object sender, EventArgs e)
    {
        popupInstance.OnButton1Pressed -= onButton1Pressed;
        popupInstance.OnButton2Pressed -= onButton2Pressed;
        popupInstance.OnPopupClosing -= onPopupClosing;
    }
}
