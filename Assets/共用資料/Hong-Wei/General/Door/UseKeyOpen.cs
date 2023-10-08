using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKeyOpen : MonoBehaviour
{
    public Item key;
    private BoxCollider2D boxCol;

    [SerializeField, Header("門的初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("往上座標位移")]
    private float offsetUp = 3;
    [SerializeField, Header("移動速度"), Range(0, 2.0f)]
    private float moveSpeed = 1.0f;

    private Vector3 pointUp => pointOriginal + Vector3.up * offsetUp;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && InventoryManager.HasKey())
        {
            StartCoroutine(MoveDoor(pointUp));
            InventoryManager.RemoveItem(key);
            boxCol.enabled = false;
        }
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            gameObject.transform.parent.position = Vector3.Lerp(pointOriginal, targetPosition, (elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.parent.position = pointUp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.5f, 0.5f);
        Gizmos.DrawSphere(pointUp, 0.1f);
    }

    [ContextMenu("取得門原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.position;
    }
}
