using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Vector2 initialPosition;
    public Rigidbody2D itemRigidbody;
    public int CurrentSceneBuildIndex;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject playerGameObject;
    private bool isEquipped = false;

    public virtual void Start()
    {
        SceneManager.activeSceneChanged += RefreshItems;
        DontDestroyOnLoad(this);
        this.gameObject.transform.position = initialPosition;
        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        playerRigidbody = playerGameObject.GetComponent<Rigidbody2D>();
    }

    public virtual void Use()
    {
        Debug.Log($"{itemName} has been used");
    }

    public void PutInHand()
    {
        isEquipped = true;
        this.transform.SetParent(playerGameObject.transform);
    }

    public void Drop()
    {
        this.transform.SetParent(null);
        isEquipped = false;
        itemRigidbody.position = playerRigidbody.position + new Vector2(0, -130);
    }

    public void RefreshItems(Scene unloadedScene, Scene loadedScene)
    {
        if (isEquipped)
        {
            CurrentSceneBuildIndex = loadedScene.buildIndex;
        }
        else
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

    public bool IsEquipped()
    {
        return isEquipped;
    }
}
