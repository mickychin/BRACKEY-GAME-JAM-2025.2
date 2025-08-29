using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    private void Awake()
    {
        //itemSlotContainer = transform.Find("itemSlotContainer");
        //itemSlotTemplate = transform.Find("itemSlotTemplate");

        //Debug.Log(itemSlotContainer);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        if(itemSlotContainer == null)
        {
            return;
        }
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize_x = 330;
        float itemSlotCellSize_y = 120f;
        foreach (Item item in inventory.GetItemLists())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize_x, -y * itemSlotCellSize_y);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI nameText = itemSlotRectTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            nameText.text = item.itemType.ToString();

            TextMeshProUGUI amountText = itemSlotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1)
            {
                amountText.SetText("x" + item.amount.ToString());
            }
            else
            {
                amountText.SetText("");
            }

            Button button = itemSlotRectTransform.Find("Button").GetComponent<Button>();
            if (item.isInteractable())
            {
                button.gameObject.SetActive(true);
                SetButton(item, button);
            }
            else
            {
                button.gameObject.SetActive(false);
            }

                x++;
            if ( x> 1) {
                x = 0;
                y++;
            }
        }
    }

    public void SetButton(Item item, Button button)
    {
        if (item.itemType == Item.ItemType.Container)
        {
            button.onClick.AddListener(FindObjectOfType<Tool>().SetTool_TubeContainer);
        }
        else if (item.itemType == Item.ItemType.Bugnet)
        {
            button.onClick.AddListener(FindObjectOfType<Tool>().SetTool_Bugnet);
        }
        else if (item.itemType == Item.ItemType.Fly)
        {
            button.onClick.AddListener(FindObjectOfType<Food>().UseT1Food);
        }
        else if (item.itemType == Item.ItemType.Mosquito)
        {
            button.onClick.AddListener(FindObjectOfType<Food>().UseT2Food);
        }
        else if (item.itemType == Item.ItemType.Ant)
        {
            button.onClick.AddListener(FindObjectOfType<Food>().UseT3Food);
        }
    }
}
