using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public static bool isSprinting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody.freezeRotation = true;
        isSprinting = false;
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sprintAction.IsPressed())
        {
            if (stamina > 0)
            {
                playerRigidbody.linearVelocity = moveAction.ReadValue<Vector2>() * sprintSpeed * Time.deltaTime;
                isSprinting = true;
            }
            else
            {
                playerRigidbody.linearVelocity = moveAction.ReadValue<Vector2>() * speed * Time.deltaTime;
                isSprinting = false;
            }

            if (playerRigidbody.linearVelocity != Vector2.zero && stamina > 0)
            {
                stamina -= staminaUsageMultiplier * Time.deltaTime;
            }
        }
        else
        {
            isSprinting = false;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "director_in")
        {
            SceneManager.LoadScene(1); // Load pryncypała scene
        }
        else if(collision.tag == "director_out"){
            SceneManager.LoadScene(0);
        }
    }
}
