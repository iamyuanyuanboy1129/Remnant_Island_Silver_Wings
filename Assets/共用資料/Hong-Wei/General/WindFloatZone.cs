using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

public class WindFloatZone : MonoBehaviour
{
    [SerializeField, Header("漂浮力道"), Range(0, -0.5f)]
    private float forceUP;

    private bool inWindRange = false;

    private void Update()
    {
        if (inWindRange && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale += 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = forceUP;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inWindRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            inWindRange = false;
        }
    }
}
