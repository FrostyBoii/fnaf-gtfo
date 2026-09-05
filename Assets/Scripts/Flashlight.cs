using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float depth = 10.0f;

    private Vector2 mousePosition;
    private Vector3 mouseWithDepth;
    private Vector3 worldPosition;

    private Light2D flashlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        flashlight = GetComponent<Light2D>();
        flashlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mouseWithDepth = new Vector3(mousePosition.x, mousePosition.y, depth);
        worldPosition = mainCamera.ScreenToWorldPoint(mouseWithDepth);
        transform.position = worldPosition;

        if (Keyboard.current.fKey.isPressed)
        {
            flashlight.enabled = true;
        }
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            flashlight.enabled = false;
        }
    }


}
