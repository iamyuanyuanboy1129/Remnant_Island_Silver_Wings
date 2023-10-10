using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferLocation : MonoBehaviour
{
    [SerializeField, Header("偏移量")]
    private Vector3 offset = Vector3.right;

    private Vector3 turnBackPoint => transform.position + offset;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.9f, 0.3f, 0.3f, 0.7f);
        Gizmos.DrawSphere(turnBackPoint, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = turnBackPoint;
        }
    }
}
