using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    /// <summary>
    /// Boss追蹤系統
    /// </summary>
    public class StateBossTrack : State
    {
        [SerializeField, Header("角色的初始座標")]
        private Vector3 pointOriginal;
        [SerializeField, Header("走路速度"), Range(0, 5)]
        private float walkSpeed = 3f;
        [SerializeField, Header("跑步速度"), Range(0, 10)]
        private float runSpeed = 5f;
        [SerializeField, Header("跳躍攻擊冷卻"), Range(0, 10)]
        private float cdJumpAtk = 10f;
        [SerializeField, Header("跳躍後等待時間"), Range(0, 10)]
        private float closeAtkTriggerTime = 3f;

        private HealthSystem healthSystem;
        private Transform player;
        private Rigidbody2D rig;
        public int direction = 1;
        public bool canJumpAtk = true;
        public bool canCloseAtk = true;
        private bool jumpTrigger = false;
        public float timer = 0;
        public bool canMove = true;

        private string parWalk = "開關走路";
        private string parRun = "開關跑步";

        [Header("追蹤區域")]
        [SerializeField]
        private Vector3 trackSize = Vector3.one;
        [SerializeField]
        private Vector3 trackOffset;

        [Header("跳躍攻擊範圍")]
        [SerializeField]
        private Vector3 jumpAtkSize = Vector3.one;
        [SerializeField]
        private Vector3 jumpAtkOffset;

        [Header("近攻擊範圍")]
        [SerializeField]
        private Vector3 nearAtkSize = Vector3.one;
        [SerializeField]
        private Vector3 nearAtkOffset;

        [SerializeField, Header("跳躍攻擊狀態")]
        private StateBossJumpAttack jumpAttack;
        [SerializeField, Header("近攻擊狀態")]
        private StateBossCloseAttack closeAttack;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 1f, 0f, 0.1f);
            Gizmos.DrawCube(pointOriginal + transform.TransformDirection(trackOffset), trackSize);

            Gizmos.color = new Color(1, 0f, 0f, 0.3f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(jumpAtkOffset), jumpAtkSize);

            Gizmos.color = new Color(1, 0f, 1f, 0.3f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(nearAtkOffset), nearAtkSize);
        }
        private void Start()
        {
            healthSystem = GetComponent<HealthSystem>();
            player = GameObject.Find("Player_Idle").transform;
            rig = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            timer += Time.deltaTime;
            //print(timer);
            if (timer >= cdJumpAtk)
            {
                canJumpAtk = true;
                timer = 0;
            }
            if (timer >= closeAtkTriggerTime && jumpTrigger)
            {
                jumpTrigger = false;
                canCloseAtk = true;
            }
        }
        public override State RunCurrentState()
        {
            if (TrackTarget())
            {
                if (TriggerJumpAttack() && canJumpAtk)
                {
                    timer = 0;
                    jumpTrigger = true;
                    canJumpAtk = false;
                    canCloseAtk = false;
                    return jumpAttack;
                }
                if (TriggerCloseAttack() && canCloseAtk)
                {
                    canMove = false;
                    return closeAttack;
                }
                if ((healthSystem.currentHealth/healthSystem.maxHealth) > 0.5f && canMove)
                {
                    ani.SetBool(parWalk, true);
                    FlipToPlayer();
                    rig.velocity = new Vector2(direction * walkSpeed, rig.velocity.y);
                }
                else if((healthSystem.currentHealth / healthSystem.maxHealth) <= 0.5f && canMove)
                {
                    ani.SetBool(parRun, true);
                    FlipToPlayer();
                    rig.velocity = new Vector2(direction * runSpeed, rig.velocity.y);
                }
            }
            return this;
        }
        /// <summary>
        /// 判斷是否追蹤
        /// </summary>
        /// <returns></returns>
        public bool TrackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(pointOriginal + transform.TransformDirection(trackOffset), trackSize, 0, layerTarget);
            return hit;
        }

        public bool TriggerJumpAttack()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(jumpAtkOffset), jumpAtkSize, 0, layerTarget);
            return hit;
        }

        public bool TriggerCloseAttack()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(nearAtkOffset), nearAtkSize, 0, layerTarget);
            return hit;
        }
        private void FlipToPlayer()
        {
            if (player.transform.position.x < transform.position.x)
            {
                direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
        public void ResetState()
        {
            
        }

        [ContextMenu("取得角色原始座標")]
        private void GetOriginalPoint()
        {
            pointOriginal = transform.position;
        }
    }
}
