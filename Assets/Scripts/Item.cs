using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public Rigidbody2D itemRigidbody;
    private bool isEquipped = false;
    [SerializeField] private string itemName;
    [SerializeField] private Vector2 initialPosition;
    public int CurrentSceneBuildIndex;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject playerGameObject;

    private void Awake()
    {
        playerGameObject = GameObject.FindWithTag("Player");

        if (playerGameObject != null)
        {
            playerRigidbody = playerGameObject.GetComponent<Rigidbody2D>();
        }

        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Start()
    {
        SceneManager.activeSceneChanged += RefreshItems;
        DontDestroyOnLoad(this);
        this.gameObject.transform.position = initialPosition;
        this.gameObject.SetActive(false);
    }

    public virtual void Use()
    {
        Debug.Log("Item used");
    }

    public void PutInHand()
    {
        if (playerGameObject != null)
        {
            isEquipped = true;
            transform.SetParent(playerGameObject.transform);
        }
    }

    // DODAJEMY TO
    public void Drop()
    {
        transform.SetParent(null);
        isEquipped = false;

        if (itemRigidbody != null && playerRigidbody != null)
        {
            itemRigidbody.position = playerRigidbody.position + new Vector2(0, -130);
        }
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