using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class PlatformArcedToMove : MonoBehaviour
{
    [SerializeField, Header("中心點")]
    private Vector3 centerPoint;
    [SerializeField, Header("是否順時針旋轉")]
    private bool isClockWise = true;
    [SerializeField, Header("移動速度")]
    private float speed = 2f;
    [SerializeField, Header("初始角度")]
    private float degree = 0f;

    private float radius;
    private float radian;
    private float originalRadian;
    private float endRadian;


    private void Start()
    {
        radius = Vector3.Distance(centerPoint, transform.position);
        originalRadian = degree * Mathf.PI / 180f;
        radian = originalRadian;
    }

    void Update()
    {
        if (isClockWise)
        {
            endRadian = (degree - 360) * Mathf.PI / 180;
            if (radian > endRadian)
            {
                radian -= speed * Time.deltaTime;
            }
            else radian = originalRadian;
        }
        else
        {
            endRadian = (degree + 360) * Mathf.PI / 180;
            if (radian < endRadian)
            {
                radian += speed * Time.deltaTime;
            }
            else radian = originalRadian;
        }

        float x = radius * Mathf.Cos(radian) + centerPoint.x;
        float y = radius * Mathf.Sin(radian) + centerPoint.y;

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
