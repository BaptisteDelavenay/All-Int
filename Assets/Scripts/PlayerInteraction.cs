using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactMask;

    [SerializeField] private TMP_Text promptText;
    [SerializeField] private Inventory inventory;

    private Outline currentOutline;
    private Pickup currentPickup;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        Outline newOutline = null;
        currentPickup = null;

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask, QueryTriggerInteraction.Collide))
        {
            newOutline = hit.collider.GetComponentInParent<Outline>();
            currentPickup = hit.collider.GetComponentInParent<Pickup>();
        }

        if (newOutline != currentOutline)
        {
            if (currentOutline != null) currentOutline.enabled = false;
            if (newOutline != null) newOutline.enabled = true;
            currentOutline = newOutline;
        }

        promptText.gameObject.SetActive(currentPickup != null);
        if (currentPickup != null)
            promptText.text = currentPickup.Prompt;

        if (currentPickup != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentPickup.Collect(inventory);
            currentOutline = null;
            promptText.gameObject.SetActive(false);
        }
    }
}