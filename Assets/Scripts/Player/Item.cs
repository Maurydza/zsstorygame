using UnityEngine;

class Item : MonoBehaviour
{
    [SerializeField] private string name;
    public Rigidbody2D itemRigidbody;
    [SerializeField] private GameObject itemObject;
    [SerializeField] private Rigidbody2D playerRigidbody;
    private bool isEquipped = false;

    public virtual void Use()
    {
        Debug.Log($"{name} has been used");
    }

    public void PutInHand()
    {
        isEquipped = true;
    }

    public void Drop()
    {
        isEquipped = false;
        itemRigidbody.position = playerRigidbody.position + new Vector2(0, -130);
    }

    public bool IsEquipped()
    {
        return isEquipped;
    }
}
