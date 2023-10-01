using Fungus;
using System.Collections;
using System.Collections.Generic;
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
    private float speed = 0.01f;

    /// <summary>
    /// 方向 : 往上+1  往下-1
    /// </summary>
    private int direction = 1;

    private Vector3 pointUp => pointOriginal + Vector3.up * offsetUp;
    private Vector3 pointDown => pointOriginal + Vector3.down * offsetDown;

    private void Update()
    {
        MoveAndFlip();
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
        transform.position += new Vector3(0, direction * speed, 0);
    }

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.position;
    }
}
