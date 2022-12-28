using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject model;

    [SerializeField]
    private TextMeshProUGUI accelDisplay;

    private readonly bool isColliding;

    private Rigidbody rb;
    private AccelControl accelControl;

    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = model.GetComponent<Rigidbody>();
        accelControl = model.GetComponent<AccelControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get velocity
        velocity = Vector3.Magnitude(rb.velocity);

        // QoL checks
        StopRotationWhenHalted();
        DebugText(false);
    }

    private void DebugText(bool debugModeOn)
    {
        if (debugModeOn)
        {
            accelDisplay.text =
                $"Current Orientation: {Input.acceleration}\n"
                + $"Orientation Delta: {accelControl.TiltValue}\n"
                + $"Tilt Magnitude: {accelControl.FlatMagnitude}\n"
                + $"Friction: {accelControl.SlidingFrictionVector}\n"
                + $"Velocity: {velocity}\n"
                + $"canMove? {(accelControl.FlatMagnitude > Mathf.Pow(accelControl.InitialFriction, 2) ? "True" : "False")}\n"
                + $"isColliding? {(isColliding ? "True" : "False")}\n";
        }
        else
        {
            accelDisplay.text = null;
        }
    }

    private void StopRotationWhenHalted()
    {
        if (velocity <= 0.025f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
