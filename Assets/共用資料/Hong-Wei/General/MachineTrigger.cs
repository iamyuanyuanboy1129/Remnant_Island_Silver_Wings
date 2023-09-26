using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrigger : MonoBehaviour
{
    [SerializeField, Header("物件移動")]
    private GameObject platform;
    [SerializeField, Header("物件判定")]
    private LayerMask layerTarget;
    private Animator ani;
    private BoxCollider2D box;
    private bool isArrive = false;
    private bool isFirstStart = true;

    private void Awake()
    {
        ani = platform.GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {

        if (AttackTarget() && Input.GetKeyDown(KeyCode.V))
        {
            if (!isFirstStart)
            {
                if (isArrive)//抵達上方才執行往下移動
                {
                    ani.SetTrigger("Move");
                    isArrive = false;
                }
                isArrive = true;
            }
            ani.SetTrigger("Start");
            isArrive = true;
            isFirstStart = false;
        }
    }


    public bool AttackTarget()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(box.offset), box.size, 0, layerTarget);
        return hit;
    }
}
