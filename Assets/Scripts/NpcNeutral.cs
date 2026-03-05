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

    public GameObject continueButton;
    public float wordSpeed;
    public  bool playerIsClose;
    // Update is called once per frame


    void Start()
    {

        interraction = InputSystem.actions.FindAction("Interact");
        interraction.Enable();
    }
    void Update()
    {
        if(interraction.IsPressed() && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroExit();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogueLines[index])
        {
            continueButton.SetActive(true);
        }
    }


    public void zeroExit()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogueLines[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
    }

    public void NextLine()
    {

        continueButton.SetActive(false);

        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroExit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroExit();
        }
    }
}

