using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotation : MonoBehaviour
{
    [SerializeField, Header("中心點")]
    private GameObject center;
    [SerializeField, Header("轉動速度"), Range(10, 100)]
    private float rotationSpeed = 50;
    [SerializeField, Header("是否順時針")]
    private bool isClockWise = true;

    private void Update()
    {
        transform.RotateAround(center.transform.position, isClockWise ? Vector3.back : Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
