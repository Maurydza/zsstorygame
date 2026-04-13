using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NpcNeutral : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogueLines;
    private int index;
    private InputAction interraction;

    private Coroutine typingCoroutine;

    public GameObject continueButton;
    public float wordSpeed;
    public  bool playerIsClose;
    // Update is called once per frame


    void Start()
    {
        // for pressing E to interact with the npc
        interraction = InputSystem.actions.FindAction("Interact");
        playerIsClose = false;
    }
    void Update()
    {
        // if the player is close and presses the interact button, the dialogue panel will appear and the dialogue will start typing
        if (interraction.WasPressedThisFrame() && playerIsClose)
        {
            
            if (dialoguePanel.activeInHierarchy)
            {
                zeroExit();

            }
            else
            {
                dialoguePanel.SetActive(true);

                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine); // Stop the previous typing coroutine if it's still running
                }


                typingCoroutine = StartCoroutine(Typing()); // Start the typing coroutine
            }
        }

        //if the dialogue is fully typed, the continue button will appear

        if (dialogueText.text == dialogueLines[index])
        {
            continueButton.SetActive(true);
        }
    }

    // this function will reset the dialogue and hide the dialogue panel
    public void zeroExit()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    
    // this function will type the dialogue letter by letter with a delay between each letter
    IEnumerator Typing()
    {
        dialogueText.text = "";

        foreach (char letter in dialogueLines[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
    }

    // this function will be called when the continue button is pressed, it will move to the next line of dialogue or exit if it's the last line
    public void NextLine()
    {

        continueButton.SetActive(false);

        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = "";
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            

            StartCoroutine(Typing());
        }
        else
        {
            zeroExit();
        }
    }

    // this function will be called when the player enters the trigger area of the npc, it will set the playerIsClose variable to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerIsClose = true;

            
        }
    }

    // this function will be called when the player exits the trigger area of the npc, it will set the playerIsClose variable to false and reset the dialogue
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroExit();
            
        }
    }
}

