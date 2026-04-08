using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI selectedHandText;
    [SerializeField] GameObject playerObject;
    private static Item leftHandItem;
    private static Item rightHandItem;
    public static GameObject leftHandObject;
    public static GameObject rightHandObject;
    private bool rightHandSelected;
    private InputAction lkeyAction;
    private InputAction rkeyAction;
    private InputAction equipAction;
    private InputAction dropAction;
    private InputAction changeHandAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftHandItem = null;
        rightHandItem = null;
        rightHandSelected = false;
        lkeyAction = InputSystem.actions.FindAction("UseLeft");
        rkeyAction = InputSystem.actions.FindAction("UseRight");
        equipAction = InputSystem.actions.FindAction("Interact");
        dropAction = InputSystem.actions.FindAction("Drop");
        changeHandAction = InputSystem.actions.FindAction("ChangeHand");
    }

    // Update is called once per frame
    void Update()
    {
        if (changeHandAction.WasPressedThisFrame())
        {
            rightHandSelected = !rightHandSelected;
            if (rightHandSelected)
            {
                selectedHandText.text = "Ręka: prawa";
            }
            else
            {
                selectedHandText.text = "Ręka: lewa";
            }
        }

        if (lkeyAction.WasPressedThisFrame())
        {
            if (leftHandItem != null)
            {
                leftHandItem.Use();
            }
        }

        if (rkeyAction.WasPressedThisFrame())
        {
            if (rightHandItem != null)
            {
                rightHandItem.Use();
            }
        }

        if (dropAction.WasPressedThisFrame())
        {
            if (rightHandSelected)
            {
                if (rightHandItem != null)
                {
                    playerObject.GetComponent<LyingItemsSpawner>().AddItem(rightHandItem.originalPrefab, rightHandItem.transform.position);
                    rightHandItem.Drop();
                    rightHandItem = null;
                    rightHandObject = null;
                }
                else
                {
                    Debug.Log("no item to drop");
                }
            }
            else
            {
                if (leftHandItem != null)
                {
                    playerObject.GetComponent<LyingItemsSpawner>().AddItem(leftHandItem.originalPrefab, leftHandItem.transform.position);
                    leftHandItem.Drop();
                    leftHandItem = null;
                    leftHandObject = null;
                }
                else
                {
                    Debug.Log("no item to drop");
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (equipAction.IsPressed())
        {
            if (rightHandSelected)
            {
                if (collision.CompareTag("Item") && rightHandItem == null)
                {
                    if (!collision.GetComponent<Item>().IsEquipped())
                    {
                        rightHandItem = collision.GetComponent<Item>();
                        rightHandItem.PutInHand();
                        rightHandObject = rightHandItem.gameObject;
                        playerObject.GetComponent<LyingItemsSpawner>().RemoveItem(rightHandItem.index);
                    }
                    else
                    {
                        Debug.Log("this item is already equipped");
                    }
                }
                else
                {
                    Debug.Log("hand already in use");
                }
            }
            else
            {
                if (collision.CompareTag("Item") && leftHandItem == null)
                {
                    if (!collision.GetComponent<Item>().IsEquipped())
                    {
                        leftHandItem = collision.GetComponent<Item>();
                        leftHandItem.PutInHand();
                        leftHandObject = leftHandItem.gameObject;
                        playerObject.GetComponent<LyingItemsSpawner>().RemoveItem(leftHandItem.index);
                    }
                    else
                    {
                        Debug.Log("this item is already equipped");
                    }
                }
                else
                {
                    Debug.Log("hand already in use");
                }
            }
        }
    }

    public static bool IsLHINull()
    {
        if (leftHandItem  == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsRHINull()
    {
        if (rightHandItem == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void LHITransform(Vector2 position)
    {
        leftHandItem.itemRigidbody.position = position;
    }

    public static void RHITransform(Vector2 position)
    {
        rightHandItem.itemRigidbody.position = position;
    }
}
