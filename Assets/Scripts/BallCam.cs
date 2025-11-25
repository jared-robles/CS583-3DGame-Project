using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineOrbitalFollow))]
public class BallCam : MonoBehaviour
{
    [Header("Inscribed")]
    public float lookSensitivity = 1f; // Camera sensitivity factor

    public float zoomSensitivity = 1f; // Camera zoom speed
    public float minRange = 1f; // Closest zoom range
    public float maxRange = 5f; // Farthest zoom range

    CinemachineCamera cam; 
    CinemachineOrbitalFollow camOrbit; // Must use a Cinemachine Orbital Follow camera

    // User-defined in Input System, these inputs control parts of the camera
    InputAction moveCamera; // Moves the camera on input
    InputAction zoomCamera; // Changes camera zoom on input
    
    void Start()
    {
        // Get a reference to the Cinemachine camera
        // Have it track the golf ball (must be tagged "Ball" in Inspector)
        // The Cinemachine camera and the tagged golf ball must be in the same scene before runtime
        cam = GetComponent<CinemachineCamera>();
        cam.Follow = GameObject.FindGameObjectWithTag("Ball").transform;

        camOrbit = GetComponent<CinemachineOrbitalFollow>(); // Get a reference to the Cinemachine Orbit Follow component
        moveCamera = InputSystem.actions.FindAction("ClickDrag"); // Set as right-click and drag
        zoomCamera = InputSystem.actions.FindAction("Zoom"); // Set as the mouse scroll wheel

        moveCamera.Enable();
        zoomCamera.Enable();
    }

    void Update()
    {
        // Only move when right mouse button is held
        if (Mouse.current != null && Mouse.current.rightButton.isPressed)
        {
            Vector2 delta = moveCamera.ReadValue<Vector2>();
            camOrbit.HorizontalAxis.Value += delta.x * lookSensitivity * Time.deltaTime;
            camOrbit.VerticalAxis.Value -= delta.y * lookSensitivity * Time.deltaTime;
        }

        float rad = zoomCamera.ReadValue<float>();
        float currRad = camOrbit.RadialAxis.Value;
        float zoomVal = currRad + (rad * zoomSensitivity * Time.deltaTime);
        camOrbit.RadialAxis.Value = Mathf.Clamp(zoomVal, minRange, maxRange);
    }
}
