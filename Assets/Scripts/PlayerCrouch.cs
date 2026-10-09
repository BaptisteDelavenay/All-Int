using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCrouch : MonoBehaviour
{

    [SerializeField] Volume volume;
    [SerializeField] private Transform cameraRoot;
    [SerializeField] private CharacterController controller;
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private float vignetteIntensity = 0.2f; // Intensité de la vignette au crouch du joueur
    [SerializeField] private float crouchSpeedMultiplier = 0.5f; // Multiplicateur de vitesse lors du crouch
    [SerializeField] private float crouchHeight = 1f; // Hauteur du joueur lors du crouch
    [SerializeField] private float crouchCameraHeight = 0.9f; // Hauteur des yeux lors du crouch
    [SerializeField] private float crouchAnimationSpeed = 4f; // Durée de l'animation crouch => pas crouch et inversement
    [SerializeField] private float vignetteAnimationSpeed = 4f; // Durée de l'animation crouch => pas crouch et inversement
    private bool isCrouching;
    private float baseCameraHeight;
    private float baseMoveSpeed;
    private float baseHeight;
    private float baseSprintSpeed;
    private Vignette vignette;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        // Initialiser les valeures par défaut de hauteur et de vitesse
        baseMoveSpeed = firstPersonController.MoveSpeed;
        baseSprintSpeed = firstPersonController.SprintSpeed;
        baseHeight = controller.height;
        baseCameraHeight = cameraRoot.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Est ce que le joeuur est accrouppi ?
        isCrouching = Keyboard.current.ctrlKey.isPressed; 
    
        // Si il est accroupi alors la hauteur du joueur correspond a la hauteur accroupi, sinon hauteur normale
        float targetHeight = isCrouching ? crouchHeight : baseHeight;
        controller.height = Mathf.MoveTowards(controller.height, targetHeight, crouchAnimationSpeed * Time.deltaTime);

        // Recentrer le collider 
        controller.center = new Vector3(0,controller.height/2f,0);

        // Si il est accroupi alors la vitesse de déplacement du joueur correspond a la vitesse de déplacement accroupi, sinon vitesse de déplacement normale
        firstPersonController.MoveSpeed = isCrouching ? baseMoveSpeed * crouchSpeedMultiplier : baseMoveSpeed;

        // Si il est accroupi alors la vitesse de sprint du joueur correspond a la vitesse de sprint accroupi, sinon vitesse de sprint normale
        firstPersonController.SprintSpeed = isCrouching ? baseMoveSpeed * crouchSpeedMultiplier : baseSprintSpeed;
    
        // Ajustement de la hauteur de la caméra en fonction de si le joueur crouch ou non
        float cameraheight = isCrouching ? crouchCameraHeight : baseCameraHeight;

        Vector3 targetCameraHeight = new Vector3(cameraRoot.localPosition.x, cameraheight, cameraRoot.localPosition.z);

        // permet une animation fluide de la postion debout à crouch et inversement
        cameraRoot.localPosition = Vector3.Lerp(cameraRoot.localPosition, targetCameraHeight ,crouchAnimationSpeed * Time.deltaTime);

        if (vignette != null)
        {
            float targetIntensity = isCrouching ? vignetteIntensity : 0f;
            vignette.intensity.value = Mathf.MoveTowards(vignette.intensity.value, targetIntensity, vignetteAnimationSpeed * Time.deltaTime);
        }
    }
}
