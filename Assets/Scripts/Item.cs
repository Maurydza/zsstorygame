using UnityEngine;
using UnityEngine.SceneManagement;

class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    public Rigidbody2D itemRigidbody;
    public int CurrentSceneBuildIndex;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject playerGameObject;
    public GameObject originalPrefab;
    private bool isEquipped = false;
    public int index;

    private void Update()
    {
        Debug.Log(index);
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
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        isEquipped = false;
        itemRigidbody.position = playerRigidbody.position + new Vector2(0, -130);
    }

    public bool IsEquipped()
    {
        return isEquipped;
    }
}
