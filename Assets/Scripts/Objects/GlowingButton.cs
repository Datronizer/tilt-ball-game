using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingButton : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        SendMessageUpwards("ShuffleGlowingSquare", false);
        SendMessageUpwards("AddScore", 1);
    }
}
