using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public TextMeshProUGUI slotNum;
    public string slotInfo;
    public int slotID;

    public GameObject itemInSlot;
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotInfo);
    }
    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHold.ToString();
        slotInfo = item.itemInfo;
    }
}
