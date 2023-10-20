using TwoD;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField, Header("跳躍力道"), Range(0, 20)]
    private float jumpPower = 10;
    [SerializeField, Header("落下增幅")]
    private float fallMultiplier;
    [SerializeField, Header("跳躍增幅")]
    private float jumpMultiplier;
    [SerializeField, Header("跳躍時間")]
    private float jumpTime;
    [SerializeField, Header("是否能夠水平移動")]
    public bool movementEnable = true;
    [SerializeField, Header("是否能夠躲藏")]
    public bool canHide = false;
    [SerializeField, Range(0, 5000), Header("閃避力道")]
    public float dodgeSpeed = 1000f;
    [SerializeField, Header("面對方向")]
    public int direction = 1;

    private Rigidbody2D rig;
    private Animator ani;
    private string parRun = "isRun";
    private string parJump = "isJump";

    public int health = 100;
    public int gold = 0;

    public Quest quest;
    public GameObject player;
    private Vector2 vecGravity;
    private bool isJumping;
    private float jumpCounter;

    [SerializeField, Header("受傷反彈力"), Range(0, 10)]
    public float hurtForce;
    public bool isHurt;
    public bool isDead;

    public bool isAttack;

    public UnityEngine.SceneManagement.Scene scene;
    [SerializeField, Header("當前場景名稱")]
    public string sceneName;
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
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    public void Start()
    {
        //print("<color=yellow>開始事件</color>")    
        player = gameObject;
        //儲存目前場景位置。
        SaveCurrentScene();
    }

    public void Update()
    {
        if (isAttack || player.GetComponent<FireSystem>().isHolyAttack)
        {
            rig.velocity = new Vector3(0, rig.velocity.y);
        }
        //print("<color=yellow>更新事件</color>")
        if (!isHurt && !isAttack && !player.GetComponent<FireSystem>().isHolyAttack)
        {
            Move();
        }
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
        if (movementEnable)
        {
            rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);
            //if (Input.GetKey(KeyCode.LeftArrow))
            if (h < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                direction = -1;
            }
            //else if (Input.GetKey(KeyCode.RightArrow))
            else if (h > 0)
            {
                transform.eulerAngles = Vector3.zero;
                direction = 1;
            }
            ani.SetBool(parRun, h != 0);
        }
        //躲藏系統
        if ((Input.GetKeyDown(KeyCode.UpArrow) && canHide) || (Input.GetKeyDown(KeyCode.W) && canHide))
        {
            movementEnable = false;
            rig.velocity = Vector3.zero;
            ani.SetBool(parRun, false);
            GetComponent<CapsuleCollider2D>().excludeLayers = LayerMask.GetMask("enemy");
            GetComponent<HealthSystem>().invulnerable = true;
            GetComponent<HealthSystem>().invulnerableCounter = 900f;
            player.layer = LayerMask.NameToLayer("Default");
            ///躲避變透明
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            movementEnable = true;
            GetComponent<CapsuleCollider2D>().excludeLayers = LayerMask.GetMask("Nothing");
            GetComponent<HealthSystem>().invulnerable = false;
            GetComponent<HealthSystem>().invulnerableCounter = 0f;
            player.layer = LayerMask.NameToLayer("player");
            ///恢復正常
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.UseItem("高級回復藥");
        }
    }
    /// <summary>
    /// 判斷是否在地面，並且按空白鍵跳躍
    /// </summary>
    public void Jump()
    {
        if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
        {
            //rig.AddForce(new Vector2(0, jumpPower));
            rig.velocity = new Vector2(rig.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }

        if (rig.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentjumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentjumpM = jumpMultiplier * (1 - t);
            }

            rig.velocity += vecGravity * currentjumpM * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rig.velocity.y > 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.6f);
            }
        }

        if (rig.velocity.y < 0)
        {
            rig.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }
    /// <summary>
    /// 檢查角色是否在地板
    /// </summary>
    /// <returns>是否在地板上</returns>
    public bool CheckGround()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
        ani.SetBool(parJump, !hit);
        return hit;
    }
    /// <summary>
    /// 人物受傷
    /// </summary>
    public void PlayHurt()
    {
        ani.SetTrigger("hurt");
        ani.SetBool("isRun", false);
    }
    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rig.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;

        rig.AddForce(dir * hurtForce, ForceMode2D.Impulse);

    }
    /// <summary>
    /// 人物死亡
    /// </summary>
    public void PlayDead()
    {
        ani.SetBool("isDead", true);
        GameObject.Find("Player_Idle").GetComponent<Player>().enabled = false;
        GameObject.Find("Player_Idle").GetComponent<FireSystem>().enabled = false;
    }
    /// <summary>
    /// 儲存目前場景位置
    /// </summary>
    public void SaveCurrentScene()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        PlayerPrefs.SetString("TargetScene", sceneName);
    }
    #endregion
}
