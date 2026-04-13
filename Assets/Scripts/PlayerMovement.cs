using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject UIGameObject;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaRegenMultiplier;
    [SerializeField] private float staminaUsageMultiplier;
    [SerializeField] TextMeshProUGUI staminaLevelText;
    [SerializeField] TextMeshProUGUI moneyLevelText;
    private float stamina;
    private InputAction moveAction;
    private InputAction sprintAction;
    public static bool isSprinting;
    public static int Money {  get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        DontDestroyOnLoad(playerGameObject);
        DontDestroyOnLoad(UIGameObject);
    }

    void Start()
    {
        playerRigidbody.freezeRotation = true;
        isSprinting = false;
        stamina = 70;
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        Money = 0;
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
        moneyLevelText.text = "Monety: " + Money.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "director_in")
        {
            PlayerTeleport.targetSpawnID = "dyr_drzwi";
            SceneManager.LoadScene(2); // Load pryncypała scene
        }
        else if(collision.tag == "director_out"){
            PlayerTeleport.targetSpawnID = "lobby_drzwi_dyr";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "s69_out")
        {
            PlayerTeleport.targetSpawnID = "lobby_drzwi_s69";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "s59_out")
        {
            PlayerTeleport.targetSpawnID = "lobby_drzwi_s59";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "s49_out")
        {
            PlayerTeleport.targetSpawnID = "lobby_drzwi_s49";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "sP1_out")
        {
            PlayerTeleport.targetSpawnID = "lobby_drzwi_sP1";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "sP2_out")
        {
            PlayerTeleport.targetSpawnID = "lobby_drzwi_sP2";
            SceneManager.LoadScene(1);
        }
        else if(collision.tag == "initialSpawnpoint")
        {
            PlayerTeleport.targetSpawnID = "initialSpawn";
            SceneManager.LoadScene(1);
        }
        else if (collision.tag == "s49_in")
        {
            PlayerTeleport.targetSpawnID = "s49_drzwi";
            SceneManager.LoadScene(3);
        }
        else if (collision.tag == "s59_in")
        {
            PlayerTeleport.targetSpawnID = "s59_drzwi";
            SceneManager.LoadScene(4);
        }
        else if (collision.tag == "s69_in")
        {
            PlayerTeleport.targetSpawnID = "s69_drzwi";
            SceneManager.LoadScene(5);
        }
        else if (collision.tag == "sP1_in")
        {
            PlayerTeleport.targetSpawnID = "sP1_drzwi";
            SceneManager.LoadScene(6);
        }
        else if (collision.tag == "sP2_in")
        {
            PlayerTeleport.targetSpawnID = "sP2_drzwi";
            SceneManager.LoadScene(7);
        }

        if(collision.tag == "money")
        {
            Money += 5;
            collision.enabled = false;
            collision.GetComponent<Transform>().gameObject.SetActive(false);
            


        }

    }
}
