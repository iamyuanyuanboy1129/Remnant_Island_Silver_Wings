using UnityEngine;

public class ClearEquipItems : MonoBehaviour
{
    public void ClearEquipments()
    {
        InventoryManager.RemoveEquipItem();
    }
}
