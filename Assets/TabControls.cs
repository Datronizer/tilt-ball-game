using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabControls : MonoBehaviour
{
    public void OnTabSelected()
    {
        SendMessageUpwards("SelectTab", this.name);
        //foreach (Button tab in tabs)
        //{
        //    Image image = tab.GetComponent<Image>();
        //    image.color = Color.white;
        //}
        //HighLightTab();
    }
}
