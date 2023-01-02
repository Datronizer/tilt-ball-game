using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem : MonoBehaviour
{
    public Sprite itemSprite;

    public int itemLevel;
    public string itemName;
    public int itemScoreValue;
    
    public int price;

    public string flavorText;
}
