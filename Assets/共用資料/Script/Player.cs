using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    #region 資料
    [SerializeField, Range(0, 50), Header("移動速度")]
    public float moveSpeed = 5f;
    [SerializeField, Header("檢查地板尺寸")]
    private Vector3 v3CheckGroundSize = Vector3.one;
    [SerializeField, Header("檢查地板位移")]
    private Vector3 v3CheckGroundOffset = Vector3.zero;
    [SerializeField, Header("要偵測地板的圖層")]
    private LayerMask layerCheckGround;
    [SerializeField, Header("跳躍力道"), Range(0, 800)]
    private float jumpPower = 500;

    private Rigidbody2D rig;
    private Animator ani;
    private string parRun = "isRun";
    private string parJump = "isJump";

    public int health = 100;
    public int gold = 0;

    public Quest quest;
    #endregion

    #region 事件
    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                gold += quest.goldReward;
                quest.Complete();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
        Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
    }

    private void Awake()
    {
        //print("<color=yellow>喚醒事件</color>")
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    public void Start()
    {
        //print("<color=yellow>開始事件</color>")    

    }

    public void Update()
    {
        //print("<color=yellow>更新事件</color>")    
        Move();
        //CheckGround();
        Jump();
        //下墜動作
        ani.SetFloat("Y_Velocity", rig.velocity.y);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動與翻面
    /// </summary>
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);
        //if (Input.GetKey(KeyCode.LeftArrow))
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //else if (Input.GetKey(KeyCode.RightArrow))
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        ani.SetBool(parRun, h != 0);
    }
    /// <summary>
    /// 判斷是否在地面，並且按空白鍵跳躍
    /// </summary>
    public void Jump()
    {
        if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpPower));
        }
    }
    /// <summary>
    /// 檢查角色是否在地板
    /// </summary>
    /// <returns>是否在地板上</returns>
    private bool CheckGround()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
        ani.SetBool(parJump, !hit);
        return hit;
    } 
    #endregion
}
