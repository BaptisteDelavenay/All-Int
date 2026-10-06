using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private string itemName = "Billet";

    public string Prompt => $"[E] pour ramasser {itemName}";

    public void Collect(Inventory inventory)
    {
        inventory.Add(itemName, amount);
        Destroy(gameObject);
    }
}