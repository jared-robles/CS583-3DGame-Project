using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [SerializeField] private float shotPower = 20f;
    [SerializeField] private float stopVelocity = 0.01f;
    [SerializeField] private float maxDragDistance = 5f; // clamp power

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float lineLift = 0.05f;

    // Scoring purposes
    [SerializeField] private int par = 3; // Amount of strokes expected to clear the course
    private int hits; // Ball hit counter

    private bool isIdle = true;
    private bool isAiming;
    private new Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (lineRenderer)
        {
            lineRenderer.enabled = false;
            lineRenderer.positionCount = 2;

            lineRenderer.useWorldSpace = true;
            lineRenderer.alignment = LineAlignment.TransformZ;
            lineRenderer.transform.forward = Vector3.up;

            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
    }

    void FixedUpdate()
    {
        // Keep isIdle in sync with the real velocity
        float speedSq = rigidbody.linearVelocity.sqrMagnitude;
        float stopVelSq = stopVelocity * stopVelocity;

        if (speedSq < stopVelSq)
        {
            // Only call Stop when we actually transition from moving -> idle
            if (!isIdle)
                Stop();
        }
        else
        {
            // Ball is clearly moving
            isIdle = false;
        }
    }

    void Update()
    {
        // Only start aiming if ball is idle
        if (!isAiming && isIdle && PressedThisFrame())
        {
            isAiming = true;
            rigidbody.Sleep();
        }

        ProcessAim();
    }

    void ProcessAim()
    {
        // Don't aim if not in aiming mode or ball is not idle
        if (!isAiming || !isIdle) return;

        var worldPoint = CastPointerRay();
        if (!worldPoint.HasValue) return;

        DrawLine(worldPoint.Value);

        if (ReleasedThisFrame())
            Shoot(worldPoint.Value);
    }

    void Shoot(Vector3 worldPoint)
    {
        isAiming = false;
        if (lineRenderer) lineRenderer.enabled = false;

        Vector3 p = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 dir = (p - transform.position);
        float drag = Mathf.Min(dir.magnitude, maxDragDistance); // clamp
        Vector3 direction = dir.sqrMagnitude > 0.0001f ? dir.normalized : transform.forward;

        Vector3 impulse = -direction * (drag * shotPower);
        rigidbody.WakeUp();
        rigidbody.AddForce(impulse, ForceMode.Impulse);

        hits++; // Increment hit counter

        // We just shot, so ball is not idle anymore
        isIdle = false;

        Debug.Log($"Shoot() impulse: {impulse}, drag:{drag:F2}, shotPower:{shotPower}");
        Debug.Log($"Strokes: {hits} out of {par} pars");
    }

    void DrawLine(Vector3 worldPoint)
    {
        if (!lineRenderer) return;

        // same math as Shoot() so the line matches the real shot
        Vector3 p = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 dir = (p - transform.position);
        float drag = Mathf.Min(dir.magnitude, maxDragDistance); // clamp drag like Shoot()
        Vector3 direction = dir.sqrMagnitude > 0.0001f ? dir.normalized : transform.forward;

        // line starts at the ball, lifted a bit
        Vector3 start = transform.position + Vector3.up * lineLift;
        // we shoot opposite the drag, so point the arrow that way and scale by drag
        Vector3 end = start - direction * drag;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
    }

    void Stop()
    {
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        isIdle = true;
    }

    // ----- Input System helpers -----
    bool PressedThisFrame()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame) return true;
        return Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
    }

    bool ReleasedThisFrame()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasReleasedThisFrame) return true;
        return Mouse.current != null && Mouse.current.leftButton.wasReleasedThisFrame;
    }

    Vector2 PointerScreenPosition()
    {
        if (Touchscreen.current != null) return Touchscreen.current.primaryTouch.position.ReadValue();
        return Mouse.current != null ? Mouse.current.position.ReadValue() : Vector2.zero;
    }
    // --------------------------------

    Vector3? CastPointerRay()
    {
        var cam = Camera.main;
        if (!cam) return null;

        Vector2 pos = PointerScreenPosition();
        Ray ray = cam.ScreenPointToRay(new Vector3(pos.x, pos.y, 0f));

        // Infinite plane at the ball's height (XZ plane)
        Plane plane = new Plane(Vector3.up, new Vector3(0f, transform.position.y, 0f));

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            return hitPoint;
        }

        return null;
    }


    // Detects when the golf ball enters a trigger
    void OnTriggerEnter(Collider other)
    {
        if (hits == 1) Debug.Log("Hole in one!");
        else if (hits > 1 && hits < par) Debug.Log("Birdie!");
        else if (hits == par) Debug.Log("Par");
        else Debug.Log("Bogey");

        if (other.CompareTag("Hole"))
            Destroy(this.gameObject);
    }
}
