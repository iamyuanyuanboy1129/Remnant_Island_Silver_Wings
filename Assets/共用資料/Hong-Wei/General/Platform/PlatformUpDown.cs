using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class PlatformUpDown : MonoBehaviour
{
    [SerializeField, Header("平台的初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("往上座標位移")]
    private float offsetUp = 2;
    [SerializeField, Header("往下座標位移")]
    private float offsetDown = -2;
    [SerializeField, Header("移動速度"), Range(0, 0.05f)]
    private float moveSpeed = 0.01f;
    [SerializeField, Header("平台是否持續移動")]
    private bool isKeepMoving;

    /// <summary>
    /// 方向 : 往上+1  往下-1
    /// </summary>
    private int direction = 1;
    private bool movingUp = true;

    private Vector3 pointUp => pointOriginal + Vector3.up * offsetUp;
    private Vector3 pointDown => pointOriginal + Vector3.down * offsetDown;

    private void Update()
    {
        if (isKeepMoving)
        {
            MoveAndFlip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
        Gizmos.DrawSphere(pointUp, 0.1f);
        Gizmos.DrawSphere(pointDown, 0.1f);
    }

    private void MoveAndFlip()
    {
        if (Vector3.Distance(transform.position, pointUp) < 0.3f)
        {
            direction = -1;
        }
        if (Vector3.Distance(transform.position, pointDown) < 0.3f)
        {
            direction = 1;
        }
        transform.position += new Vector3(0, direction * moveSpeed, 0);
    }

    public void MoveTrigger()
    {
        float elapsedTime = 0f;

        if (movingUp)
        {
            while (elapsedTime < (moveSpeed * 100))
            {
                gameObject.transform.parent.position = Vector3.Lerp(pointOriginal, pointDown, (elapsedTime / (moveSpeed * 100)));
                elapsedTime += Time.deltaTime;
            }
            gameObject.transform.parent.position = pointDown;
            movingUp = false;
        }
        else
        {
            while (elapsedTime < (moveSpeed * 100))
            {
                gameObject.transform.parent.position = Vector3.Lerp(pointOriginal, pointUp, (elapsedTime / (moveSpeed * 100)));
                elapsedTime += Time.deltaTime;
            }
            gameObject.transform.parent.position = pointUp;
            movingUp = true;
        }
    }

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.position;
    }
}
