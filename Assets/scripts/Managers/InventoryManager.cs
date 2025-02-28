using System.Collections.Generic;
using UnityEngine;

public class NewInventoryManager : MonoBehaviour
{
    public static NewInventoryManager Instance;
    private List<string> inventory = new List<string>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
