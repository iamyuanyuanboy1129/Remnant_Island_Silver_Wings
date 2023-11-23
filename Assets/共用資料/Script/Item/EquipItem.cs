using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public Inventory myBag;
    
    public void EquipOnClicked()
    {
        if (myBag.itemList[PlayerPrefs.GetInt("ItemSelected")].itemType == "消耗品")
        {
            myBag.itemList[21] = myBag.itemList[PlayerPrefs.GetInt("ItemSelected")];
            myBag.itemList[21].equip = true;
            InventoryManager.RefreshItem();
        }
        else if (myBag.itemList[PlayerPrefs.GetInt("ItemSelected")].itemType == "裝備")
        {
            myBag.itemList[20] = myBag.itemList[PlayerPrefs.GetInt("ItemSelected")];
            myBag.itemList[20].equip = true;
            InventoryManager.RefreshItem();
        }
    }
}
