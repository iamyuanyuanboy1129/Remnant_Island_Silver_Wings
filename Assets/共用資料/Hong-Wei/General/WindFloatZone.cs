using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

public class WindFloatZone : MonoBehaviour
{
    private bool inWindRange = false;
    private float originalSurfaceLevel;

    private BuoyancyEffector2D effector;

    private void Start()
    {
        effector = GetComponent<BuoyancyEffector2D>();
        originalSurfaceLevel = effector.surfaceLevel;
    }

    private void Update()
    {
        if (inWindRange && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (effector.surfaceLevel > 0)
            {
                effector.surfaceLevel--;
            }
            else
            {
                effector.surfaceLevel = 0;
            }
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
            effector.surfaceLevel = originalSurfaceLevel;
            inWindRange = false;
        }
    }
}
