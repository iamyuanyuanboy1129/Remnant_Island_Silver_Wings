using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckKey : MonoBehaviour
{
    private GameObject checkKeyDialog;
    void Start()
    {
        checkKeyDialog = GameObject.Find("KeyCheck");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !InventoryManager.HasKey())
        {
            checkKeyDialog.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
