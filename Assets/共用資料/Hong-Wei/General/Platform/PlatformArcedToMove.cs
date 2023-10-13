using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlatformArcedToMove : MonoBehaviour
{
    [SerializeField, Header("中心點")]
    private Vector3 centerPoint;
    [SerializeField, Header("是否順時針旋轉")]
    private bool isClockWise = true;
    [SerializeField, Header("移動速度")]
    private float speed = 2f;
    [SerializeField, Header("初始角度")]
    private float angle = 0f;

    private float radius;


    private void Start()
    {
        radius = Vector3.Distance(centerPoint, transform.position);
    }

    void Update()
    {
        if (isClockWise)
        {
            angle -= speed * Time.deltaTime;
        }
        else
        {
            angle += speed * Time.deltaTime;
        }

        float x = radius * Mathf.Cos(angle) + centerPoint.x;
        float y = radius * Mathf.Sin(angle) + centerPoint.y;

        transform.position = new Vector3(x, y, 0f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0.8f, 0.9f, 0.7f);
        Gizmos.DrawSphere(centerPoint, 0.5f);
    }
    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        centerPoint = transform.position;
    }
}
