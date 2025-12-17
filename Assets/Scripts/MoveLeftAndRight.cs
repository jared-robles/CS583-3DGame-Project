using UnityEngine;
// Summary:
// This script is intended to move a GameObject left and right over time.
public class MoveLeftAndRight : MonoBehaviour
{
    public bool XMove = true; // Move along the X axis if true, otherwise along the Z axis
    public float speed = 1.0f; // Speed of movement
    public float leftBound = -5.0f; // Left boundary for movement
    public float rightBound = 5.0f; // Right boundary for movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(XMove) // Move along the X axis
        {
            // Calculate new X position using PingPong for smooth back-and-forth movement
            float newX = leftBound + (Mathf.PingPong(Time.time * speed, rightBound - leftBound));
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else
        {
            // Calculate new Z position using PingPong for smooth back-and-forth movement
            float newZ = leftBound + (Mathf.PingPong(Time.time * speed, rightBound - leftBound));
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
    }
}
