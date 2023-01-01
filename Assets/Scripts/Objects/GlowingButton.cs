using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingButton : MonoBehaviour
{
    [SerializeField] private int buttonValue;

    private void OnTriggerStay(Collider other)
    {
        SendMessageUpwards("ShuffleGlowingSquare", false);
        SendMessageUpwards("AddScore", buttonValue);
    }
}
