using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject playerGameObject;
    protected Rigidbody2D playerRigidbody;

    public Rigidbody2D itemRigidbody;

    private bool isEquipped = false;

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
        // nic
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
            itemRigidbody.position = playerRigidbody.position + new Vector2(0, -1);
        }
    }

    public bool IsEquipped()
    {
        return isEquipped;
    }
}