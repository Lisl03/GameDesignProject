using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public event Action<string> OnItemCollected;

    public void ItemCollected(string itemName)
    {
        OnItemCollected?.Invoke(itemName);
    }
}
