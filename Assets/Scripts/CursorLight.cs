
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class CursorLight : MonoBehaviour
{
    private Camera mainCamera;
    private Light2D flashlight;

    void Start()
    {
        mainCamera = Camera.main;
        flashlight = GetComponentInChildren<Light2D>();

        if (flashlight != null)
        {
            flashlight.enabled = false;
        }
    }

    void Update()
    {
        if (mainCamera == null)
            return;

        if (Mouse.current != null)
        {
            Vector3 mousePosition =
                mainCamera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
        }

        if (Keyboard.current != null &&
            Keyboard.current.lKey.wasPressedThisFrame &&
            flashlight != null)
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
