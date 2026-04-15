using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject uiGameObject;
    [SerializeField] private PlayerFollow cameraFollow;
    [SerializeField] private GameObject instructions;

    public void StartGame()
    {
        cameraFollow.Unlock();
        uiGameObject.SetActive(true);
        //foreach(GameObject go in GameObject.FindGameObjectsWithTag("money"))
        //{
        //    go.InitializePosition();
        //}
        SceneManager.LoadScene(1);
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        instructions.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("dobranoc");
        Application.Quit();
    }
    
}
