using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton Reference

    private List<string> inventory = new List<string>();

    void Awake()
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
    }

    public void AddItem(string item)
    {
        if (!inventory.Contains(item))
        {
            inventory.Add(item);
            Debug.Log(item + " added to inventory.");
        }
    }

    public bool HasItem(string item)
    {
        return inventory.Contains(item);
    }

    public void RemoveItem(string item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log(item + " removed from inventory.");
        }
    }
}
