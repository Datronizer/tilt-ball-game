using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log($"{collider.name} is on {name}");
        transform.position = new Vector3(transform.position.x, -0.22f, transform.position.z);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
    }
}
