using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera; // Caméra du joueur
    [SerializeField] private float interactionDistance = 3.0f; // Distance à laquelle le joueur peut intéragir avec un objet
    [SerializeField] private LayerMask interactMask; // Choisir le masque sur lequel le raycast fonctionnera. Le but est de le faire fonctionner uniquement sur les objets collectibles
    [SerializeField] private Inventory inventory; // Inventaire du joueur
    private Outline currentOutline;
    RaycastHit hit; // Permet de stocker la fiche des infos de l'objet touché par le Raycast

    void Update()
    {

        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward); // Créé le raycast avec la position de départ, arrivée
        bool isLookingAt = Physics.Raycast(ray, out hit, interactionDistance, interactMask); // Lancer le rayacst

        Outline newOutline = null;

        if(isLookingAt) // Si il regarde un élément
        {
            PickUp pickup = hit.collider.GetComponent<PickUp>(); // On regarde si hit.collider (l'object que l'on regarde) a un script Pickup ( qui nous permet de récupérer le nom de l'item)
            newOutline = hit.collider.GetComponent<Outline>();

            if (pickup != null) // Si il contient un script alors on affiche le nom de l'item défini dans PickUp.cs
            {
                if(Keyboard.current.eKey.wasPressedThisFrame) // Si la touche E est préssé
                {
                    inventory.Add(pickup.ItemName,1); // On ajoute 1 quantité dans l'inventaire avec la méthode Add écrite dans Inventory.cs
                    Destroy(pickup.gameObject); // On détruit l'objet pour le faire disparaitre de la scène
                    newOutline = null;
                }
            }
        }

        if(newOutline != currentOutline)
        {
            if (currentOutline != null)
            {
                currentOutline.enabled=false;
            }
            if (newOutline != null)
            {
                newOutline.enabled=true;
            }
            currentOutline=newOutline;
        }

       
    }
}
