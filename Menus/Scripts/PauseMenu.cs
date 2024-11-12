using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent onPaused;
    [SerializeField] private UnityEvent onUnpaused;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private TMP_Text currentObjective;
    [SerializeField] private SaveData saveData;
    
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
            var currentMilestone = saveData.GetMilestone(saveData.GetValue<string>("MainMission"));
            currentObjective.SetText("Current Mission: " + currentMilestone.Objective);
            onPaused.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            onUnpaused.Invoke();
        }
    }

    public async void GoToMainMenu()
    {
        await saveData.SaveAsync();
        sceneTransition.TransitionToScene("MainMenu", false, "FadeToBlack");
        Time.timeScale = 1;
    }

    public async void CloseGame()
    {
#if UNITY_STANDALONE
        await saveData.SaveAsync();
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
