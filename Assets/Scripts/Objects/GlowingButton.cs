using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SendMessageUpwards("ShuffleGlowingSquare", false);
        SendMessageUpwards("AddScore", 1);
    }

    private void OnTriggerStay(Collider other)
    {
        SendMessageUpwards("ShuffleGlowingSquare", false);
        SendMessageUpwards("AddScore", 1);
    }
}
