using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI; // Das Panel für das Inventar
    public List<Image> itemSlots = new List<Image>(); // Die UI-Slots für Items
    private List<Sprite> items = new List<Sprite>(); // Die gespeicherten Items
    private bool isOpen = false;

    void Start()
    {
        // Stelle sicher, dass das Inventar beim Start ausgeblendet ist
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(false);
        }
        else
        {
            Debug.LogError("inventoryUI wurde nicht zugewiesen! Bitte im Inspector setzen.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryUI.SetActive(isOpen);
        }
    }

    public void AddItem(Sprite itemSprite)
    {
        if (items.Count < itemSlots.Count)
        {
            items.Add(itemSprite);
            UpdateUI();
        }
        else
        {
            Debug.Log("Inventar ist voll!");
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < items.Count)
                itemSlots[i].sprite = items[i]; // Sprite setzen
            else
                itemSlots[i].sprite = null; // Leeren Slot zurücksetzen
        }
    }
}
