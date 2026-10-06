using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera; // Caméra du joueur
    [SerializeField] private float interactionDistance = 3.0f; // Distance à laquelle le joueur peut intéragir avec un objet
    [SerializeField] private LayerMask interactMask; // Choisir le masque sur lequel le raycast fonctionnera. Le but est de le faire fonctionner uniquement sur les objets collectibles
    RaycastHit hit; // Permet de stocker la fiche des infos de l'objet touché par le Raycast

    void Update()
    {
        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        bool isLookingAt = Physics.Raycast(ray, out hit, interactionDistance, interactMask);

        if(isLookingAt)
        {
            Debug.Log($"Le RayCast fonctionne ! Vous avez visé {hit.collider.name}");
        }
    }
}
