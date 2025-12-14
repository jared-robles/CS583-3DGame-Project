using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Respawn : MonoBehaviour
{
    [Header("Out of bounds")]
    [SerializeField] private float yKillHeight = -5f;          // if ball falls below this, respawn
    [SerializeField] private Vector3 spawnOffset = new Vector3(0f, 0.1f, 0f);

    private Rigidbody rb;
    private Vector3 lastShotPosition;
    private bool hasCheckpoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // starting position is a valid checkpoint
        lastShotPosition = transform.position;
        hasCheckpoint = true;
    }

    void FixedUpdate()
    {
        // check if ball falls out of bounds
        if (transform.position.y < yKillHeight)
        {
            BallRespawn();
        }
    }

    
    public void SaveShotCheckpoint()
    {
        lastShotPosition = transform.position;
        hasCheckpoint = true;
    }

    public void BallRespawn()
    {
        if (!hasCheckpoint)
        {
            // fallback, use current position if somehow no checkpoint
            lastShotPosition = transform.position;
        }

        // reset physics
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // move ball back to last shot position
        transform.position = lastShotPosition + spawnOffset;
    }
    // OPTIONAL METHOD: use this if we decide to have the out of bounds as a trigger
    void OnTriggerEnter(Collider other)
    {
        // any trigger tagged OutOfBounds will respawn to last shot position
        if (other.CompareTag("OutOfBounds"))
        {
            BallRespawn();
        }
    }
}


