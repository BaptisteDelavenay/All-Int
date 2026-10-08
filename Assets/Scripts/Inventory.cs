using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();
    [SerializeField] private TMP_Text InventoryDisplay; // Inventaire (texte en haut a gauche de l'écran) 
    [SerializeField] private int billValue = 10; // Valeure du billet. Ex : 1 billet = 10$ 
    [SerializeField] private int money = 0; // Qtt argent dans l'inventaire
    [SerializeField] private string currency = "$"; // Devise 

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
                money+=billValue;
            }
        }

        InventoryDisplay.text = money+currency;

    }

}