using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton for global access

    public GameObject inventoryUI; // The entire inventory UI panel

    // UI Slots for predefined items
    public Image itemSlot_DollDress;
    public Image itemSlot_Vinyl;
    public Image itemSlot_Flashlight;
    public Image itemSlot_Photo;
    public Image itemSlot_Key;

    private Dictionary<string, Image> itemSlots = new Dictionary<string, Image>();
    private List<string> inventory = new List<string>(); // Inventory storage
    private const int maxItems = 5; // Maximum inventory size

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize inventory UI as hidden
        inventoryUI.SetActive(false);

        // Link item names to UI slots
        itemSlots.Add("DollDress", itemSlot_DollDress);
        itemSlots.Add("Vinyl", itemSlot_Vinyl);
        itemSlots.Add("Flashlight", itemSlot_Flashlight);
        itemSlots.Add("Photo", itemSlot_Photo);
        itemSlots.Add("Key", itemSlot_Key);

        // Make sure UI slots start hidden
        foreach (var slot in itemSlots.Values)
        {
            slot.enabled = false;
            slot.sprite = null; // Make sure no old images are shown
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Press "I" to toggle inventory UI
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    public void AddItem(string itemName)
    {
        if (inventory.Count >= maxItems)
        {
            Debug.Log("Inventory is full! Cannot add " + itemName);
            return; // Stop if max items reached
        }

        if (!inventory.Contains(itemName))
        {
            inventory.Add(itemName);
            Debug.Log(itemName + " added to inventory.");

            // Update UI if the item has a corresponding slot
            if (itemSlots.ContainsKey(itemName))
            {
                Sprite itemSprite = Resources.Load<Sprite>("Sprites/" + itemName);
                if (itemSprite != null)
                {
                    itemSlots[itemName].sprite = itemSprite;
                    itemSlots[itemName].enabled = true; // Make visible
                }
                else
                {
                    Debug.LogWarning("Missing sprite for item: " + itemName);
                }
            }
        }
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        if (inventory.Contains(itemName))
        {
            inventory.Remove(itemName);
            Debug.Log(itemName + " removed from inventory.");

            // Hide UI slot if it exists
            if (itemSlots.ContainsKey(itemName))
            {
                itemSlots[itemName].sprite = null;
                itemSlots[itemName].enabled = false; // Hide it
            }
        }
    }

    public bool IsInventoryFull()
    {
        return inventory.Count >= maxItems;
    }
}