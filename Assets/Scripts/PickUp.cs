using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private string itemName = "Billet";
    public string ItemName => itemName;

    void Start()
    {
        // Permet de désactiver le contour du billet au démarrage du jeu. Il sera alors visible qu'a partir du moment ou le joueur passe le crosshair desus
        Outline outline = GetComponent<Outline>();
        if(outline != null)
        {
            outline.enabled = false;
        }
    }

    void Update()
    {
        
    }
}
