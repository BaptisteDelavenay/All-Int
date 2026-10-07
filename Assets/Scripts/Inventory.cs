using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();
    [SerializeField] private TMP_Text InventoryDisplay; // Inventaire (texte en haut a gauche de l'écran) 
    [SerializeField] private int money = 0; // Inventaire (texte en haut a gauche de l'écran) 
    [SerializeField] private string currency = "$"; // Inventaire (texte en haut a gauche de l'écran) 

    public void Start()
    {
        UpdateDisplay();
    }

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
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {

        foreach (KeyValuePair<string, int> item in items)
        {
            if(item.Key=="Billet")
            {
                money+=10;
            }
        }

        InventoryDisplay.text = money+currency;

    }

}