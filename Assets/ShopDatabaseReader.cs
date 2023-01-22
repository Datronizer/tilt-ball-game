using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDatabaseReader : MonoBehaviour
{
    public ShopItem[] shopItems;
    public TextAsset jsonFile;
    public GameObject shopItemTemplate;

    private void Start()
    {
        ShopContentManager shopItemsInJson = JsonUtility.FromJson<ShopContentManager>(jsonFile.text);

        foreach (ShopItem obstacles in shopItemsInJson.shopItems)
        {
            GameObject newItem = Instantiate(shopItemTemplate, this.gameObject.transform);
            ShopItem details = newItem.GetComponent<ShopItem>();

            details.itemSprite = obstacles.itemSprite;
            details.itemName = obstacles.itemName;
            details.flavorText = obstacles.flavorText;

            details.itemLevel = obstacles.itemLevel;
            details.itemScoreValue = obstacles.itemScoreValue;
            details.price = obstacles.price;

            details.multiplier = obstacles.multiplier;
        }
    }
}
