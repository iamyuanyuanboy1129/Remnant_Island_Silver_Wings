using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

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
