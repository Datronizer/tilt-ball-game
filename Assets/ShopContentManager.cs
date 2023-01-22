using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopContentManager : MonoBehaviour
{
    public TabControls[] tabs;
    public ShopItem[] shopItems;
    public TextAsset jsonFile;
    public GameObject shopItemTemplate;

    void PopulateShopContent()
    {
        ShopContentManager shopItemsInJson = JsonUtility.FromJson<ShopContentManager>(jsonFile.text);

        foreach (ShopItem shopItem in shopItemsInJson.shopItems)
        {
            GameObject newItem = Instantiate(shopItemTemplate, this.gameObject.transform);
            ShopItem details = newItem.GetComponent<ShopItem>();

            details.itemSprite = shopItem.itemSprite;
            details.itemName = shopItem.itemName;
            details.flavorText = shopItem.flavorText;

            details.itemLevel = shopItem.itemLevel;
            details.itemScoreValue = shopItem.itemScoreValue;
            details.price = shopItem.price;

            details.multiplier = shopItem.multiplier;
        }
    }

    private void Start()
    {
        PopulateShopContent();
    }

}
