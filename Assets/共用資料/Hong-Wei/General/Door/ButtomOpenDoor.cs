using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomOpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("啟動");
            Destroy(door.gameObject);
        }
    }
}
