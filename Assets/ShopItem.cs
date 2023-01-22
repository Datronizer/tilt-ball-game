using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem : MonoBehaviour
{
    // Intangible data
    public Sprite itemSprite;
    public string itemName;
    public string flavorText;

    public int maxLevel;

    // Tangible data
    public int itemLevel;
    public int itemScoreValue;
    public int price;

    public float multiplier;
}
