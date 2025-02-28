using UnityEngine;

public class PlushieManager : MonoBehaviour
{
    public GameObject plushie;
    private bool hasEye, hasStuffing, hasSewingKit;

    public void CheckPlushie()
    {
        hasEye = NewInventoryManager.Instance.HasItem("PlushieEye");
        hasStuffing = NewInventoryManager.Instance.HasItem("PlushieStuffing");
        hasSewingKit = NewInventoryManager.Instance.HasItem("SewingKit");

        if (hasEye && hasStuffing && hasSewingKit)
        {
            Debug.Log("Plüschtier repariert!");
            GameMaster.Instance.ChangeEmotionalStability(50);
        }
        else
        {
            DialogueManager.Instance.StartDialogue("PlushieNotFixed");
        }
    }
}
