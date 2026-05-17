using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPCharacter : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCDialogues dialogueData;
    [SerializeField] private TMP_Text nameText, dialogueText;
    [SerializeField] private GameObject dialoguePanel;

    private int indexDialogue;
    private bool isTyping, dialogueActive = false;




    public bool PuedeInteractuar(GameObject objetoInteractuar)
    {
        return true;
    }

    public void Interactuar(GameObject objetoInteractuar)
    {
        Debug.Log("Interactuando");

        if (dialogueData == null )
        {
            Debug.Log("dialogonull");
            return;
        }


        if (dialogueActive==true)
        {
            Debug.Log("activo");
            NextLine();
        }

        else
        {
            Debug.Log("start");
            StartDialogue();
        }
    }


    void StartDialogue()
    {

        dialogueActive = true;
        indexDialogue = 0;

        nameText.SetText(dialogueData.NPCName);

        dialoguePanel.SetActive(true);

        StartCoroutine(TypeText());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[indexDialogue]);
            isTyping = false;
        }
        else if (indexDialogue + 1 < dialogueData.dialogueLines.Length)
        {
            indexDialogue += 1;
            StartCoroutine(TypeText());
        }
        else
        {
            EndDialogue();
        }
    }


    public void EndDialogue()
    {
        StopAllCoroutines();
        dialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letra in dialogueData.dialogueLines[indexDialogue])
        {
            dialogueText.text += letra;
            yield return new WaitForSeconds(dialogueData.typeSpeed);
        }

        isTyping = false;

        if (dialogueData.automaticLines.Length > indexDialogue && dialogueData.automaticLines[indexDialogue])
        {
            yield return new WaitForSeconds(dialogueData.progressDelay);
            NextLine();
        }
    }


}
