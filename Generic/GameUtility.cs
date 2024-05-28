using UnityEngine;
using UnityEngine.InputSystem;

public class GameUtility : MonoBehaviour
{
    public void ToggleFullScreen(InputAction.CallbackContext context)
    {
        if (context.performed) { ToggleFullScreen(); }

    }
    public void ToggleFullScreen()
    {
        SetFullScreen(!Screen.fullScreen);
    }
    public void SetFullScreen(bool fullScreenValue)
    {
        Screen.fullScreen = fullScreenValue;
        if (!fullScreenValue)
        {
            Resolution resolution = Screen.currentResolution;
            Screen.SetResolution(resolution.width, resolution.height, fullScreenValue);
        }

    }
}
