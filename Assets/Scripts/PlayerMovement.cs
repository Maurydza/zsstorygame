using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaRegenMultiplier;
    [SerializeField] private float staminaUsageMultiplier;
    [SerializeField] TextMeshProUGUI staminaLevelText;
    private float stamina;
    private InputAction moveAction;
    private InputAction sprintAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        if (sprintAction.IsPressed())
        {
            if (stamina > 0)
            {
                playerRigidbody.linearVelocity = moveAction.ReadValue<Vector2>() * sprintSpeed * Time.deltaTime;
            }
            else
            {
                playerRigidbody.linearVelocity = moveAction.ReadValue<Vector2>() * speed * Time.deltaTime;
            }

            if (playerRigidbody.linearVelocity != Vector2.zero && stamina > 0)
            {
                stamina -= staminaUsageMultiplier * Time.deltaTime;
            }
        }
        else
        {
            playerRigidbody.linearVelocity = moveAction.ReadValue<Vector2>() * speed * Time.deltaTime;

            if (stamina < maxStamina)
            {
                stamina += staminaRegenMultiplier * Time.deltaTime;
            }
            else
            {
                stamina = maxStamina;
            }
        }

        staminaLevelText.text = "Stamina: " + ((int)stamina).ToString();
    }
}
