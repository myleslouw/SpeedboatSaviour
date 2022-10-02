using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class NPC : MonoBehaviour
{

    public CinemachineVirtualCamera npcCamera;     //each NPC has a virtual cam attached that the player will switch to when they in range (collider)
    DialogueManager dialogueManager;
    public DialogueObj dialogue;
    public string npcName;

    private void Start()
    {
        npcName = dialogue.npcName;
    }

}
