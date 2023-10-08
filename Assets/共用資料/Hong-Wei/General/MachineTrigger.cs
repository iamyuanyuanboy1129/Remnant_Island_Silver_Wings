using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrigger : MonoBehaviour
{
    [SerializeField, Header("平台的初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("往上座標位移")]
    private float offsetUp = 2;
    [SerializeField, Header("往下座標位移")]
    private float offsetDown = -2;
    [SerializeField, Header("移動速度"), Range(0, 2.0f)]
    private float moveSpeed = 1.0f;
    [SerializeField, Header("提示按鈕物件")]
    private GameObject hintObj;

    private bool movingUp = true;
    private bool inTriggerRange = false;

    private Vector3 pointUp => pointOriginal + Vector3.up * offsetUp;
    private Vector3 pointDown => pointOriginal + Vector3.down * offsetDown;

    private void Update()
    {
        if (inTriggerRange&&Input.GetKeyDown(KeyCode.F))
        {
            if (movingUp)
            {
                StartCoroutine(Move(pointUp, pointDown));
                movingUp = false;
            }
            else
            {
                StartCoroutine(Move(pointDown, pointUp));
                movingUp = true;
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerRange = true;
            hintObj.SetActive(true);
            //Debug.Log($"<color=red>{collision.tag}</color>");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerRange = false;
            hintObj.SetActive(false);
        }
    }

    private IEnumerator Move(Vector3 originalPosition, Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            gameObject.transform.parent.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.parent.position = targetPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.5f, 0.5f, 0.7f);
        Gizmos.DrawSphere(pointUp, 0.1f);
        Gizmos.DrawSphere(pointDown, 0.1f);
    }

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.parent.position;
    }
}
