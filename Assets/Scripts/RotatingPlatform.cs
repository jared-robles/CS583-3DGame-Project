using UnityEngine;
using System.Collections;
//Summary
// Objects with this script will rotate around their Y-axis.
public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeed = 45f; // Degrees per second
    public bool clockwise = true; // Direction of rotation
    public bool delay = false; // If true, rotation will stop after doing a full rotation for a bit, then start again
    public float delayDuration = 2f; // Duration of the delay in seconds
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (clockwise)
        {
            rotationSpeed = -Mathf.Abs(rotationSpeed);
        }
        else
        {
            rotationSpeed = Mathf.Abs(rotationSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the platform around its Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        if (delay && Mathf.Abs(transform.eulerAngles.y % 360) < 0.1f) // Check for full rotation
        {
            StartCoroutine(DelayRotation());
        }
    }
    private IEnumerator DelayRotation()
    {
        float originalSpeed = rotationSpeed;
        rotationSpeed = 0; // Stop rotation
        yield return new WaitForSeconds(delayDuration); // Wait for the specified duration
        rotationSpeed = originalSpeed; // Resume rotation
    }
    //Something doesn't seem to be working
}

//StartCorotine is used to pause the rotation for a specified duration
