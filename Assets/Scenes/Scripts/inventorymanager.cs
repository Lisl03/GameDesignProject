using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton für globalen Zugriff
    public GameObject inventoryUI; // Das gesamte Inventar-UI

    // UI-Image-Felder für die vordefinierten Inventar-Slots
    public Image itemSlot_DollDress;
    public Image itemSlot_Vinyl;
    public Image itemSlot_Flashlight;
    public Image itemSlot_Photo;
    public Image itemSlot_Key;

    private Dictionary<string, Image> itemSlots = new Dictionary<string, Image>();
    private HashSet<string> collectedItems = new HashSet<string>(); // Gesammelte Items

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

        // Inventar beim Start unsichtbar machen
        inventoryUI.SetActive(false);

        // Verknüpfe Item-Namen mit den UI-Images
        itemSlots.Add("DollDress", itemSlot_DollDress);
        itemSlots.Add("Vinyl", itemSlot_Vinyl);
        itemSlots.Add("Flashlight", itemSlot_Flashlight);
        itemSlots.Add("Photo", itemSlot_Photo);
        itemSlots.Add("Key", itemSlot_Key);

        // Stelle sicher, dass die Slots anfangs leer sind
        foreach (var slot in itemSlots.Values)
        {
            slot.enabled = false; // Unsichtbar machen
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // "I" zum Öffnen/Schließen
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    public void CollectItem(string itemName)
    {
        if (itemSlots.ContainsKey(itemName) && !collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            itemSlots[itemName].sprite = Resources.Load<Sprite>("Sprites/" + itemName);
            itemSlots[itemName].enabled = true; // Sichtbar machen
        }
    }

    public bool HasItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }
}
