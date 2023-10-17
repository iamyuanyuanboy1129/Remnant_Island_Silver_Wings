using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformOnTheWay : MonoBehaviour
{
    [SerializeField, Header("平台的初始座標")]
    private Vector3 pointOriginal;
    [SerializeField, Header("左邊座標位移")]
    private float offsetLeft = -2;
    [SerializeField, Header("移動速度"), Range(0, 0.05f)]
    private float speed = 0.01f;

    public float t;
    
    private Vector3 pointEnd => pointOriginal + Vector3.right * offsetLeft;

    private void Update()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float timer = 0;
        while (timer < t)
        {
            transform.position = Vector3.Lerp(pointOriginal, pointEnd, (timer / t));
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(MoveBack());
    }

    private IEnumerator MoveBack()
    {
        float timer = 0;
        while (timer < t)
        {
            transform.position = Vector3.Lerp(pointEnd, pointOriginal, (timer / t));
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
        Gizmos.DrawSphere(pointEnd, 0.5f);
    }

   

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        pointOriginal = transform.position;
    }
}
