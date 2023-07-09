using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField]
    private bool restartEnabled = true;
    private MenuControls menuControls;

    private void OnEnable()
    {
        menuControls = new MenuControls();
        menuControls.Menus.Enable();
        menuControls.Menus.Restart.performed += Restart_performed;
    }

    private void OnDisable()
    {
        menuControls.Menus.Restart.performed -= Restart_performed;
    }

    private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (restartEnabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
