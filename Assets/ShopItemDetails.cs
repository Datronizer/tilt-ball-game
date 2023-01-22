using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemDetails : MonoBehaviour
{
    private ShopItem shopItem;

    private Image image;
    private TextMeshProUGUI descriptor;
    private Button buyButton;

    private void Awake()
    {
        GrabComponents();
        ParseDataIntoComponents();
    }

    void GrabComponents()
    {
        shopItem = GetComponent<ShopItem>();

        image = GetComponentInChildren<Image>();
        descriptor = GetComponentInChildren<TextMeshProUGUI>();
        buyButton = GetComponentInChildren<Button>();
    }

    void ParseDataIntoComponents()
    {
        image.sprite = shopItem.itemSprite;

        descriptor.text = $"(Level {shopItem.itemLevel}) {shopItem.itemName}\n" +
            $"Square worth: {shopItem.itemScoreValue * shopItem.multiplier} (post-multiplier)\n" +
            $"Multiplier: {(shopItem.multiplier > 1 ? shopItem.multiplier : "")}x";

        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Buy\n" +
            $"({shopItem.price})";
    }
}
