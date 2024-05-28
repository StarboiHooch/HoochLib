using UnityEngine;

public class SceneDoor : MonoBehaviour
{
    [SerializeField]
    private string destinationSceneName;
    [SerializeField]
    private SceneTransition sceneTransition;
    [SerializeField]
    private bool active = true;
    public void SetActive(bool active) => this.active = active;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            sceneTransition.TransitionScenes(destinationSceneName);
        }
    }
}
