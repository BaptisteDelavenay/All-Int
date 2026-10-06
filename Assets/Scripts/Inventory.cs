using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly Dictionary<string, int> items = new Dictionary<string, int>();

    public void Add(string itemName, int amount = 1)
    {
        items[itemName] = items.TryGetValue(itemName, out int n) ? n + amount : amount;
        Debug.Log($"Ramassé : {itemName} x{amount} (total : {items[itemName]})");
    }
}