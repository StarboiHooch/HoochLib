using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private string TransitionOutAnimationName;
    [SerializeField]
    private string TransitionInAnimationName;
    [SerializeField]
    private UnityEvent SceneTransitionStarted;
    [SerializeField]
    private UnityEvent TransitionOutAnimationEnded;
    [SerializeField]
    private UnityEvent TransitionInAnimationEnded;

    [SerializeField]
    private SaveData saveData;

    private Animator animator;

    private string sceneToTransitionTo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayTransitionInAnimation();
    }

    public void TransitionScenes(string Scene)
    {
        saveData.SaveValue("PreviousScene", SceneManager.GetActiveScene().name);
        SceneTransitionStarted?.Invoke();
        sceneToTransitionTo = Scene;
        PlayTransitionOutAnimation();
    }
    public void PlayTransitionOutAnimation()
    {
        animator.Play(TransitionOutAnimationName);
    }
    public void PlayTransitionInAnimation()
    {
        animator.Play(TransitionInAnimationName);
    }
    public void AnimationOutEnded()
    {
        TransitionOutAnimationEnded?.Invoke();
    }

    public void GoToRequestedScene()
    {
        SceneManager.LoadScene(sceneToTransitionTo, LoadSceneMode.Single);
    }
    
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public void AnimationInEnded()
    {
        TransitionInAnimationEnded?.Invoke();
    }
}
