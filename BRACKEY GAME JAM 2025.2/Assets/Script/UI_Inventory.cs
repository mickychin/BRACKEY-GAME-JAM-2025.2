using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        //itemSlotTemplate = transform.Find("itemSlotTemplate");

        //Debug.Log(itemSlotContainer);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize_x = 500;
        float itemSlotCellSize_y = 120f;
        foreach (Item item in inventory.GetItemLists())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize_x, -y * itemSlotCellSize_y);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI name = itemSlotRectTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            name.text = item.itemType.ToString();

             x++;
            if ( x> 1) {
                x = 0;
                y++;
            }
        }
    }
}
