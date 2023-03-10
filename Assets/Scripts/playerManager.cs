using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerManager : MonoBehaviour
{
    [SerializeField] private Light lightEmitter;
    [SerializeField] private GameObject model;

    [SerializeField] private TextMeshProUGUI accelDisplay;

    [SerializeField] private bool isColliding;

    private Rigidbody rb;
    private Collider modelCollider;
    private AccelControl accelControl;

    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = model.GetComponent<Rigidbody>();
        modelCollider = model.GetComponent<Collider>();
        accelControl = model.GetComponent<AccelControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get velocity
        velocity = Vector3.Magnitude(rb.velocity);

        // Makes the light moves with the model (parenting is garbo)
        Vector3 modelPosition = model.transform.position;
        lightEmitter.transform.position = new Vector3(modelPosition.x, modelPosition.y + 0.25f, modelPosition.z);

        // QoL checks
        PreventClippingOffWorld();
        StopRotationWhenHalted();
        DebugText(true);
    }

    private void DebugText(bool debugModeOn)
    {
        if (debugModeOn)
        {
            accelDisplay.text = $"Current Orientation: {Input.acceleration}\n" +
            $"Orientation Delta: {accelControl.tiltValue}\n" +
            $"Tilt Magnitude: {accelControl.flatMagnitude}\n" +
            $"Friction: {accelControl.slidingFrictionVector}\n" +
            $"Velocity: {velocity}\n" +
            $"canMove? {(accelControl.flatMagnitude > Mathf.Pow(accelControl.initialFriction, 2) ? "True" : "False")}\n" +
            $"isColliding? {(isColliding ? "True" : "False")}\n";
        }   
    }

    private void PreventClippingOffWorld()
    {
        if (model.transform.position.y <= -50)
        {
            Debug.Log("Object fell off world");
            rb.velocity = Vector3.zero;
            rb.MovePosition(new Vector3(0, 2.5f, 0));
        }
    }

    private void StopRotationWhenHalted()
    {
        if(velocity <= 0.01f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
