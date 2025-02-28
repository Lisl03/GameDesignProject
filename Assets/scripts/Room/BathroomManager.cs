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
        // Make sure InventoryManager exists
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager is missing!");
            return;
        }

        if (InventoryManager.Instance.HasItem("FishingLine"))
        {
            drainPlug.SetActive(false);
            plushieStuffing.SetActive(true);
            Debug.Log("Water drained!");
        }
        else
        {
            Debug.Log("Need Fishing Line to remove the drain plug.");
        }
    }
}
