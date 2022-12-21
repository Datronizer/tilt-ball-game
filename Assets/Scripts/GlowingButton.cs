using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boop");
        SendMessageUpwards("ShuffleGlowingSquare", false);
    }
}
