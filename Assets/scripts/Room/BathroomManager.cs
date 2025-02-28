using UnityEngine;

public class BathroomManager : MonoBehaviour
{
    public GameObject bubbles;
    public GameObject faucet;
    public GameObject drainPlug;
    public GameObject plushieStuffing;

    public void PopBubble()
    {
        bubbles.SetActive(false);
        faucet.SetActive(true);
    }

    public void DrainWater()
    {
        if (InventoryManager.Instance.HasItem("FishingLine"))
        {
            drainPlug.SetActive(false);
            plushieStuffing.SetActive(true);
        }
        else
        {
            DialogueManager.Instance.StartDialogue("NeedFishingLine");
        }
    }
}
