using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwing : MonoBehaviour
{
    [SerializeField] private float leftLimit = 0.3f;
    [SerializeField] private float rightLimit = 0.3f;
    [SerializeField] private float speed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 500;
    }

    private void Update()
    {
        SwingMove();
    }

    private void SwingMove()
    {
        if (transform.rotation.z < rightLimit && rb.angularVelocity > 0 && rb.angularVelocity < speed)
        {
            rb.angularVelocity = speed;
        }
        if (transform.rotation.z > leftLimit && rb.angularVelocity < 0 && rb.angularVelocity > -speed)
        {
            rb.angularVelocity = -speed;
        }
    }
}
