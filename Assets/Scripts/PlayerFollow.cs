using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject cameraGameObject;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float maxHorizontal;
    [SerializeField] private float maxVertical;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(cameraGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody.position.x > cameraTransform.position.x + maxHorizontal)
        {
            cameraTransform.position = new Vector3(playerRigidbody.position.x - maxHorizontal, cameraTransform.position.y, -7);
        }

        if (playerRigidbody.position.x < cameraTransform.position.x - maxHorizontal)
        {
            cameraTransform.position = new Vector3(playerRigidbody.position.x + maxHorizontal, cameraTransform.position.y, -7);
        }

        if (playerRigidbody.position.y > cameraTransform.position.y + maxVertical)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, playerRigidbody.position.y - maxVertical, -7);
        }

        if (playerRigidbody.position.y < cameraTransform.position.y - maxVertical)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, playerRigidbody.position.y + maxVertical, -7);
        }
    }
}
