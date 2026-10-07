using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void Add(string itemName, int amount)
    {
        if(items.ContainsKey(itemName))
        {
            items[itemName]+=amount;
        }
        else
        {
                items[itemName]=amount;
        }
        Debug.Log($"Ramassé : {itemName} x {amount}. Total : {items[itemName]}");
    }

}
