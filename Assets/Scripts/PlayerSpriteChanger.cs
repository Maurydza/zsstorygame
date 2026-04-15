using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpriteChanger : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite specialSprite;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSprite();
    }

    void UpdateSprite()
    {
        string sceneName = SceneManager.GetActiveScene().name.ToLower();

        if (sceneName.StartsWith("s49") ||
            sceneName.StartsWith("s59") ||
            sceneName.StartsWith("s69") ||
            sceneName.StartsWith("sp1") ||
            sceneName.StartsWith("sp2") )
        {
            sr.sprite = specialSprite;
        }
        else
        {
            sr.sprite = defaultSprite;
        }
    }
}