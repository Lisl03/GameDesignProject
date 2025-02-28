using UnityEngine;

public class LivingRoomManager : MonoBehaviour
{
    public GameObject recordPlayer;
    public GameObject vinyl;
    public GameObject needle;
    public GameObject secretCompartment;

    private bool hasNeedle = false;
    private bool hasVinyl = false;

    public void PickUpNeedle()
    {
        hasNeedle = true;
        InventoryManager.Instance.AddItem("Needle");
    }

    public void PickUpVinyl()
    {
        hasVinyl = true;
        InventoryManager.Instance.AddItem("Vinyl");
    }

    public void TryFixRecordPlayer()
    {
        if (hasNeedle && hasVinyl)
        {
            Debug.Log("Plattenspieler spielt Musik...");
            secretCompartment.SetActive(true);
        }
        else
        {
            DialogueManager.Instance.StartDialogue("RecordPlayerMissingParts");
        }
    }
}
