using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NewDialogue/NPCDialogue")]
public class NPCDialogues : ScriptableObject
{
    public string NPCName;

    public string[] dialogueLines;
    public bool[] automaticLines;

    public float typeSpeed = 0.05f;
    public float progressDelay = 1.5f;
}
