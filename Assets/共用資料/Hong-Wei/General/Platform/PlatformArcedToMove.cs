using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlatformArcedToMove : MonoBehaviour
{
    [SerializeField, Header("中心點")]
    private Vector3 centerPoint;
    public float radius = 2f;
    public float speed = 2f;
    public float angle = 0f;



    void Update()
    {
        angle -= speed * Time.deltaTime;

        float x = radius * Mathf.Cos(angle) + centerPoint.x;
        float y = radius * Mathf.Sin(angle) + centerPoint.y;

        transform.position = new Vector3(x, y, 0f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
        Gizmos.DrawSphere(centerPoint, 0.1f);
    }
    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        centerPoint = transform.position;
    }
}
