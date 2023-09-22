using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

public class WindFloatZone : MonoBehaviour
{
    [SerializeField,Header("玩家")]
    private GameObject player;
    [SerializeField, Header("漂浮力道"), Range(0,-0.5f)]
    private float forceUP;

    private Rigidbody2D gravity;

    private void Awake()
    {
        gravity = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gravity.gravityScale = forceUP;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gravity.gravityScale = 1;
    }
}
