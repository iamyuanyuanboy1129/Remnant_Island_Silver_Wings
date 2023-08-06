using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform groundpoint;
    private float InputX;

    private Rigidbody2D rig;
    private Animator ani;

    private bool isFlip = false;
    private bool isGrounded = false;
    private bool canAttack;

    public LayerMask groundmask;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    public void Update()
    {
        rig.velocity = new Vector2(moveSpeed * InputX, rig.velocity.y);
        // 判斷使用者是否有輸入移動控制 有的話讓角色進行跑步動畫的撥放
        ani.SetBool("isRun", Mathf.Abs(rig.velocity.x) > 0);
        ani.SetBool("isGrounded", isGrounded);
        ani.SetFloat("Y_Velocity", rig.velocity.y);
        // ani.SetBool("isRun",true);
        // if(Mathf.Abs(rig.velocity.x) > 0)
        // {
        //     //玩家移動 isRun -> true
        //     ani.SetBool("isRun",true);
        // }
        // else
        // {
        //     ani.SetBool("isRun",false);
        // }

        if(!isFlip)
        {
            if(rig.velocity.x < 0)
            {
                isFlip = true;
                transform.Rotate(0.0f, 180.0f, 0.0f);    
            }
        }
        else
        {
            if(rig.velocity.x > 0)
            {
                isFlip = false;
                transform.Rotate(0.0f, 180.0f, 0.0f);    
            }
        }
        //Debug.Log(Physics2D.OverlapCircle(groundpoint.position, .2f, groundmask));
        isGrounded = Physics2D.OverlapCircle(groundpoint.position, .2f, groundmask);
        canAttack = isGrounded;
    }
    public void Move(InputAction.CallbackContext context)
    {
        InputX = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, 5);
        }
    }
    public void Attack(InputAction.CallbackContext context)
    {
        //檢查玩家是否可以攻擊
        if (canAttack)
        {
            ani.SetBool("attack", true);
        }
    }
    public void EndAttack()
    {
        ani.SetBool("attack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundpoint.position, .3f);
    }
}
