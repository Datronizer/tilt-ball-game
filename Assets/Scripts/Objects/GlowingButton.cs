using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingButton : MonoBehaviour
{
    public string buttonType;
    public int buttonValue;

    private void OnTriggerStay(Collider other)
    {
        SendMessageUpwards("ShuffleGlowingSquare", false);
        SendMessageUpwards("AddScore", buttonValue);
        Destroy(this.gameObject);
    }
}
