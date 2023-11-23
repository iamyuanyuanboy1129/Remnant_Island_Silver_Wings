using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public BoxCollider2D dialogCollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.name);
        if (collision.gameObject.CompareTag("Player") && !InventoryManager.HasKey())
        {
            dialogCollider.enabled = true;
        }
    }
}
