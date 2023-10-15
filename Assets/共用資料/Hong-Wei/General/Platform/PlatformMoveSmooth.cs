using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveSmooth : MonoBehaviour
{
    [SerializeField, Header("初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("終點")]
    private Vector3 pointEnd;
    [SerializeField, Header("移動速度"), Range(0, 1)]
    private float speed;

    private float sinTime;

    private void Start()
    {
        pointOriginal = transform.position;
    }

    private void Update()
    {
        Move();
        Swap();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0.8f, 0.9f, 0.7f);
        Gizmos.DrawSphere(pointEnd, 0.5f);
    }

    private void Move()
    {
        if (transform.position != pointEnd)
        {
            sinTime += speed * Time.deltaTime;
            sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
            float t = Evaluate(sinTime);
            transform.position = Vector3.Lerp(transform.position, pointEnd, t);
        }
    }

    private void Swap()
    {
        if (transform.position != pointEnd)
        {
            return;
        }
        Vector3 t = pointOriginal;
        pointOriginal = pointEnd;
        pointEnd = t;
        sinTime = 0;
    }

    private float Evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2) + 0.5f;
    }
}
