using UnityEngine;

// Summary
// This class represents a golf ball in the game.
// Left and right controls rotate the golf ball left and right respectively.
// Up and down controls control the vertical angle of the golf ball when hit.
// The space bar is used to hit the golf ball.
// We'll make the golf ball go at a statc speed / power when hit at first, may implement a bar to represent power later.
// Use boolean flags to check if the ball is currently moving or not, to prevent multiple hits while in motion.
// The golf ball will stop moving when its speed drops below a certain threshold, simulating friction and stopping.

public class GolfBall : MonoBehaviour
{

    public float rotationMaxSpeed = 10f; // Maximum rotation speed
    public float rotationAcceleration = 0.1f; // Acceleration for rotation
    public float hitPower = 20f; // Power of the hit (May implement a power bar later)
    public float stopThreshold = 0.1f; // Speed threshold to consider the ball stationary
    private Rigidbody rb; // Rigidbody component for physics
    private bool isMoving = false; // Flag to check if the ball is moving

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Section of code to handle if the ball is moving or not
        
    }
}
