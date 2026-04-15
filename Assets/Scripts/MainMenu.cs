using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject uiGameObject;
    [SerializeField] private PlayerFollow cameraFollow;

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

    }

    public void ExitGame()
    {
        Debug.Log("dobranoc");
        Application.Quit();
    }
    
}
