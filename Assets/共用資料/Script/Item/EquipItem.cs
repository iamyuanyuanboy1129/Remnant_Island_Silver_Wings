using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public Inventory myBag;
    
    public void EquipOnClicked()
    {
        myBag.itemList[21] = myBag.itemList[PlayerPrefs.GetInt("ItemSelected")];
        InventoryManager.RefreshItem();
    }
}
