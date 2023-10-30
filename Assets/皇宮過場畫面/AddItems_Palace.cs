using UnityEngine;
namespace TwoD
{
    public class AddItems_Palace : MonoBehaviour
    {
        public Item spindle;
        public Item scissor;
        public Item healingPotion;
        public Inventory inventory;

        public void AddItemsPalace()
        {
            if (!inventory.itemList.Contains(spindle))
            {
                for (int i = 0; i < inventory.itemList.Count; i++)
                {
                    if (inventory.itemList[i] == null)
                    {
                        inventory.itemList[i] = spindle;
                        spindle.itemHold = 1;
                        break;
                    }
                }
            }
            if (!inventory.itemList.Contains(scissor))
            {
                for (int i = 0; i < inventory.itemList.Count; i++)
                {
                    if (inventory.itemList[i] == null)
                    {
                        inventory.itemList[i] = scissor;
                        scissor.itemHold = 1;
                        break;
                    }
                }
            }
            if (!inventory.itemList.Contains(healingPotion))
            {
                for (int i = 0; i < inventory.itemList.Count; i++)
                {
                    if (inventory.itemList[i] == null)
                    {
                        inventory.itemList[i] = healingPotion;
                        healingPotion.itemHold = 5;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < inventory.itemList.Count; i++)
                {
                    if (inventory.itemList[i].itemName == "高級回復藥")
                    {
                        inventory.itemList[i] = healingPotion;
                        healingPotion.itemHold = 5;
                        break;
                    }
                }
            }
            //InventoryManager.RefreshItem();
        }
    }

}
