using System.Collections.Generic;
using TMPro;
using TwoD;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public TextMeshProUGUI itemInformation;

    public GameObject equipGrid;

    public List<GameObject> slots = new List<GameObject>();

    public HealthSystem healthSystem;
    public UnityEvent<HealthSystem> OnHealthChange;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }
    /*public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.transform.localScale = Vector3.one;
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHold.ToString();
    }*/
    public static void RefreshItem()
    {
        //循環刪除背包欄位組下的子物件
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.equipGrid.transform.childCount; i++)
        {
            if (instance.equipGrid.transform.childCount == 0)
                break;
            Destroy(instance.equipGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        //重新生成對應myBag裡面的物品的slot
        for (int i = 0; i < 20; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
            instance.slots[i].transform.localScale = Vector3.one;
        }
        for (int i = 20; i <= 21; i++)
        {
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.equipGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
            instance.slots[i].transform.localScale = Vector3.one;
        }
    }

    public static void RemoveItem(Item item)
    {
        if (!instance.myBag.itemList.Contains(item))
        {
            Debug.Log("<color=red>No Item!!!</color>");
        }
        else
        {
            if (item.itemHold <= 1)
            {
                for (int i = 0; i < instance.myBag.itemList.Count; i++)
                {
                    if (instance.myBag.itemList[i] == item)
                    {
                        instance.myBag.itemList[i] = null;
                        break;
                    }
                }
                item.itemHold = 1;
            }
            else
            {
                item.itemHold--;
            }
        }

        RefreshItem();
    }

    public static void RemoveEquipItem()
    {
        if (instance.myBag.itemList[20] != null)
        {
            instance.myBag.itemList[20].equip = false;
            instance.slots[20].GetComponent<Slot>().slotImage = null;
            instance.myBag.itemList[20] = null;
        }
        if (instance.myBag.itemList[21] != null)
        {
            instance.myBag.itemList[21].equip = false;
            instance.slots[21].GetComponent<Slot>().slotImage = null;
            instance.myBag.itemList[21] = null;
        }
        RefreshItem();
    }

    public static bool HasKey()
    {
        bool hasKey = false;
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            if (instance.myBag.itemList[i] != null)
            {
                if (instance.myBag.itemList[i].itemName == "Key")
                {
                    hasKey = true;
                    break;
                }
            }
        }
        return hasKey;
    }

    public static bool HasHolySword()
    {
        bool hasHoly = false;
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            if (instance.myBag.itemList[i] != null)
            {
                if (instance.myBag.itemList[i].itemName == "阿瑞斯之劍" && instance.myBag.itemList[i].equip == true)
                {
                    hasHoly = true;
                    break;
                }
            }
        }
        return hasHoly;
    }

    public static void UseItem(string useItemName)
    {
        switch (useItemName)
        {
            case "高級回復藥":
                for (int i = 0; i < instance.myBag.itemList.Count; i++)
                {
                    if (instance.myBag.itemList[i].itemName == "高級回復藥" && instance.myBag.itemList[i].itemHold != 0 && instance.myBag.itemList[i].equip == true)
                    {
                        HealthSystem healthSystem;
                        healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
                        healthSystem.currentHealth += 50;
                        if (healthSystem.currentHealth > healthSystem.maxHealth)
                            healthSystem.currentHealth = 100;
                        instance.myBag.itemList[i].itemHold--;
                        healthSystem.OnHealthChange?.Invoke(healthSystem);
                        RefreshItem();
                        break;
                    }
                }
                break;
        }
    }
}
