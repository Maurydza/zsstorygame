using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    private InputAction pointer;
    private Vector2 pointerCoords;
    private float playerPointerAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointer = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        pointerCoords = Camera.main.ScreenToWorldPoint(pointer.ReadValue<Vector2>());
        playerPointerAngle = Mathf.Atan2(pointerCoords.y - playerRigidbody.position.y, pointerCoords.x - playerRigidbody.position.x) * Mathf.Rad2Deg - 90;
        playerRigidbody.SetRotation(playerPointerAngle);
    }
}
