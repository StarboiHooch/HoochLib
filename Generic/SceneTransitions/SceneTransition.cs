using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string transitionOutAnimationName;
    [SerializeField] private string transitionInAnimationName;
    [SerializeField] private bool setActiveScene = true;
    [SerializeField] private SaveData saveData;
    [SerializeField] private Image panel;

    private Animator animator;

    private string sceneToTransitionTo;

    public event EventHandler<EventArgs> OnTransitionInEnded;
    public event EventHandler<EventArgs> OnTransitionOutEnded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayTransitionInAnimation();
        if(setActiveScene)
            saveData.SaveValue("CurrentScene", SceneManager.GetActiveScene().name);
    }

    public void TransitionToScene(string scene)
    {
        TransitionToScene(scene, true);
    }
    
    public void TransitionToScene(string scene, bool savePreviousScene)
    {
        if(savePreviousScene)
            saveData.SaveValue("PreviousScene", SceneManager.GetActiveScene().name);
        sceneToTransitionTo = scene;
        OnTransitionOutEnded += GoToSceneOnTransitionEnded;
        PlayTransitionOutAnimation();
    }

    private void GoToSceneOnTransitionEnded(object sender, EventArgs e)
    {
        OnTransitionOutEnded -= GoToSceneOnTransitionEnded;
        GoToRequestedScene();
    }

    public void PlayTransitionOutAnimation()
    {
        animator.Play(transitionOutAnimationName);
    }

    public void PlayTransitionInAnimation()
    {
        animator.Play(transitionInAnimationName);
    }

    public void AnimationInEnded()
    {
        OnTransitionInEnded?.Invoke(this, EventArgs.Empty);
    }

    public void AnimationOutEnded()
    {
        OnTransitionOutEnded?.Invoke(this, EventArgs.Empty);
    }

    public void GoToRequestedScene()
    {
        SceneManager.LoadScene(sceneToTransitionTo, LoadSceneMode.Single);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void FadeToBlack(float time = 0.5f)
    {
        StartCoroutine(FadeToBlackCoroutine(time));
    }

    private IEnumerator FadeToBlackCoroutine(float time)
    {
        var timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            panel.color = new Color(0, 0, 0, Mathf.Clamp01(timer / time));
            yield return null;
        }

        AnimationOutEnded();
    }

    public void FadeFromBlack(float time = 0.5f)
    {
        StartCoroutine(FadeFromBlackCoroutine(time));
    }

    private IEnumerator FadeFromBlackCoroutine(float time)
    {
        var timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            panel.color = new Color(0, 0, 0, 1 - Mathf.Clamp01(timer / time));
            yield return null;
        }

        AnimationInEnded();
    }
}