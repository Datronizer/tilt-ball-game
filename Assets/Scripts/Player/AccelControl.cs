using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    // public for debug, private when done
    public Vector3 StartingOrientation { get; private set; }
    public Vector3 SlidingFrictionVector { get; private set; }
    public Vector3 TiltValue { get; private set; }
    public float FlatMagnitude { get; private set; }
    public float InitialFriction { get; private set; }

    private float slidingFrictionCoeff;
    private float moveSpeed;

    private bool desktopMode;

    // Start is called before the first frame update
    void Start()
    {
        desktopMode = true;

        if (!desktopMode)
        {
            // Grabs starting orientation to calculate the delta
            Vector3 startingOrientation = Input.acceleration;
        }

        InitialFriction = 0.2f;
        slidingFrictionCoeff = 0.5f;
        moveSpeed = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!desktopMode)
        {
            MovePlayer();
        }
        else
        {
            MovePlayerWithKeyboard();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log($"{name} collided with {collision.gameObject}");
    }

    public void Recalibrate()
    {
        StartingOrientation = Input.acceleration;
    }

    private void MovePlayer()
    {
        // Calculate tilt delta
        Vector3 currentTilt = Input.acceleration;
        TiltValue = currentTilt - StartingOrientation;

        // Necessary vectors
        Vector3 groundedTiltValue = new Vector3(TiltValue.x, 0, TiltValue.y);
        SlidingFrictionVector = new Vector3(rb.velocity.x * -slidingFrictionCoeff, 0, rb.velocity.z * -slidingFrictionCoeff);

        // Apply force if tilt magnitude passes the initial friction
        FlatMagnitude = (TiltValue.x * TiltValue.x) + (TiltValue.y * TiltValue.y);
        if (FlatMagnitude > Mathf.Pow(InitialFriction, 2))
        {
            rb.AddForce(10 * moveSpeed * groundedTiltValue);
        }
        else
        {
            // Apply friction opposite of object movement direction (does not apply for y)
            rb.AddForce(SlidingFrictionVector);
        }
    }

    private void MovePlayerWithKeyboard()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Necessary vectors
        Vector3 groundedTiltValue = new Vector3(horizontal, 0, vertical);
        SlidingFrictionVector = new Vector3(rb.velocity.x * -slidingFrictionCoeff, 0, rb.velocity.z * -slidingFrictionCoeff);

        // Apply force if tilt magnitude passes the initial friction
        rb.AddForce(4 * moveSpeed * groundedTiltValue);
        rb.AddForce(SlidingFrictionVector);
    }
}
