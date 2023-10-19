using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private float duration;
    [SerializeField] private float delayTime;

    private Vector3 targetPosition => originalPosition + offset;

    private void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("amount", offset, "time", duration, "easeType", "easeInOutSine", "loopType", "pingPong", "delay", delayTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
        Gizmos.DrawSphere(targetPosition, 0.5f);
    }

    [ContextMenu("取得平台原始座標")]
    private void GetOriginalPoint()
    {
        originalPosition = transform.position;
    }
}
