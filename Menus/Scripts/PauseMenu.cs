using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent onPaused;
    [SerializeField] private UnityEvent onUnpaused;
    [SerializeField] private SceneTransition sceneTransition;
    
    private bool isPaused = false;

    private void Start()
    {
        Pause(false);
    }
    public void TogglePause()
    {
        Pause(!isPaused);
    }

    public void Pause(bool pause)
    {
        isPaused = pause;
        if (pause)
        {
            Time.timeScale = 0;
            onPaused.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            onUnpaused.Invoke();
        }
    }

    public void GoToMainMenu()
    {
        sceneTransition.TransitionToScene("MainMenu", false, "FadeToBlack");
        Time.timeScale = 1;
    }

    public void CloseGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
