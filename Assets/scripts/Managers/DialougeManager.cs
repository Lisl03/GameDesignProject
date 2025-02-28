using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public Text dialogueText;
    private Queue<string> dialogueQueue = new Queue<string>();

    public delegate void DialogueEndHandler();
    public event DialogueEndHandler OnDialogueEnd;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartDialogue(string npcID)
    {
        dialoguePanel.SetActive(true);
        dialogueQueue.Clear();

        List<string> dialogue = GetDialogue(npcID);
        foreach (string line in dialogue)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        dialogueText.text = dialogueQueue.Dequeue();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        OnDialogueEnd?.Invoke();
    }

    private List<string> GetDialogue(string npcID)
    {
        switch (npcID)
        {
            case "Mirror":
                return new List<string> { "Ah, you are finally awake.", "This world needs you..." };
            case "RecordPlayerMissingParts":
                return new List<string> { "The record player is broken...", "Something is missing?" };
            case "NeedFishingLine":
                return new List<string> { "The drain is too far...", "Maybe I can use something to pull it?" };
            case "PlushieNotFixed":
                return new List<string> { "My plushie is still broken...", "I need more materials." };
            default:
                return new List<string> { "..." };
        }
    }
}
