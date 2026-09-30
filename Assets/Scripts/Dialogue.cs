using UnityEngine;
using TMPro;
using System.Collections;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed; //time between letters appearing on the screen
    private bool isTyping;
    private int index;

    void OnEnable()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping == true)
            {
                //Currently typing - skip to show full text
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
                isTyping = false;
            }
            else if (dialogueText.text == dialogueLines[index])
            {
                //That line is complete so it shows the next line
                NextLine();
            }
        }        
    }

    public void NextDialogue()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[index];
            isTyping = false;
        }
        else if (dialogueText.text == dialogueLines[index])
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = string.Empty;
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Player_Movement.instance.canMove = true;
            Player_Interaction.instance.canInteract = true;
        }
    }
}