using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{
    [SerializeField, Header("平台的初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("左邊座標位移")]
    private float offsetLeft = -2;
    [SerializeField, Header("右邊座標位移")]
    private float offsetRight = 2;
    [SerializeField, Header("移動速度"), Range(0, 0.05f)]
    private float speed = 0.01f;

    /// <summary>
    /// 方向 : 往右+1  往左-1
    /// </summary>
    private int direction = 1;

    private Vector3 pointLeft => pointOriginal + Vector3.right * offsetLeft;
    private Vector3 pointRight => pointOriginal + Vector3.right * offsetRight;

    private void Update()
    {
        MoveAndFlip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
        Gizmos.DrawSphere(pointLeft, 0.1f);
        Gizmos.DrawSphere(pointRight, 0.1f);
    }

    private void MoveAndFlip()
    {
        if (Vector3.Distance(transform.position, pointRight) < 0.3f)
        {
            direction = -1;
        }
        if (Vector3.Distance(transform.position, pointLeft) < 0.3f)
        {
            direction = 1;
        }
        transform.position += new Vector3(direction * speed, 0, 0);
    }

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.position;
    }
}
