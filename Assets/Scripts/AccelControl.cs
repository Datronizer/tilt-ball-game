using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    // public for debug, private when done
    public Vector3 startingOrientation;
    public Vector3 slidingFrictionVector;
    public Vector3 tiltValue;
    public float flatMagnitude;
    public float initialFriction;

    private float slidingFrictionCoeff;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Grabs starting orientation to calculate the delta
        Vector3 startingOrientation = Input.acceleration;

        initialFriction = 0.2f;
        slidingFrictionCoeff = 0.5f;
        moveSpeed = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate tilt delta
        Vector3 currentTilt = Input.acceleration;
        tiltValue = currentTilt - startingOrientation;

        // Necessary vectors
        Vector3 groundedTiltValue = new Vector3(tiltValue.x, 0, tiltValue.y);
        slidingFrictionVector = new Vector3(rb.velocity.x * -slidingFrictionCoeff, 0, rb.velocity.z * -slidingFrictionCoeff);

        // Apply force if tilt magnitude passes the initial friction
        flatMagnitude = (tiltValue.x * tiltValue.x) + (tiltValue.y * tiltValue.y);
        if (flatMagnitude > Mathf.Pow(initialFriction, 2))
        {
            rb.AddForce(groundedTiltValue * moveSpeed);
        }
        else
        {
            // Apply friction opposite of object movement direction (does not apply for y)
            rb.AddForce(slidingFrictionVector);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{name} collided with {collision.gameObject}");
    }

    public void Recalibrate()
    {
        startingOrientation = Input.acceleration;
    }
}
