using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    private InputAction escapeAction;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private GameObject exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        escapeAction = InputSystem.actions.FindAction("Escape");
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeAction.WasPressedThisFrame() && SceneManager.GetActiveScene().buildIndex != 0)
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        exitButton.SetActive(!exitButton.activeSelf);
        cancelButton.SetActive(!cancelButton.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        ToggleMenu();
    }
}
