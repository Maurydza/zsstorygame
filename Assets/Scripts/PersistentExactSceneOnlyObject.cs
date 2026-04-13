using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentExactSceneOnlyObject : MonoBehaviour
{
    [SerializeField] private Vector2 initialPosition;
    public int CurrentSceneBuildIndex;
    private bool wasCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.activeSceneChanged += RefreshObjects;
        DontDestroyOnLoad(this);
        wasCollected = false;
        this.gameObject.transform.position = initialPosition;
    }

    public void RefreshObjects(Scene unloadedScene, Scene loadedScene)
    {
        if (!wasCollected)
        {
            if (CurrentSceneBuildIndex == loadedScene.buildIndex)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void MarkCollected()
    {
        wasCollected = true;
    }
}
