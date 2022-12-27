using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfWorldCatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("Object fell off world");

        Rigidbody rb = player.GetComponent<Rigidbody>();
        TeleportBackToLevel(rb);
        SendMessageUpwards("AddDeath", 1);
    }

    private void TeleportBackToLevel(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.MovePosition(new Vector3(0, 2.5f, 0));
    }
}
