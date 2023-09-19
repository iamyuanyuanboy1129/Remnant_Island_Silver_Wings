using UnityEngine;

namespace TwoD
{

    public class StateTrack : State
    {
        [SerializeField, Header("追蹤速度"), Range(0, 5)]
        private float speed = 2f;
        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;
        [Header("攻擊區域")]
        [SerializeField]
        private Vector3 attackSize = Vector3.one;
        [SerializeField]
        private Vector3 attackOffset;
        [SerializeField, Header("攻擊狀態")]
        private StateAttack stateAttack;

        private Rigidbody2D rig;
        private string parWalk = "開關走路";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(attackOffset), attackSize);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        public override State RunCurrentState()
        {
            if (stateWander.TrackTarget())
            {
                if (!AttackTarget())
                {
                    ani.SetBool(parWalk, true);
                    ani.speed = 3;
                    rig.velocity = new Vector2(speed * stateWander.direction, rig.velocity.y);


                    return this;
                }
                else
                {
                    ResetState();
                    return stateAttack;
                }
            }
            else
            {
                ResetState();
                return stateWander;
            }
        }
        /// <summary>
        /// 重設狀態資料
        /// </summary>
        private void ResetState()
        {
            ani.SetBool(parWalk, false);
            ani.speed = 1f;
            rig.velocity = Vector3.zero;
        }
        /// <summary>
        /// 攻擊目標碰撞檢測
        /// </summary>
        /// <returns>是否有目標進入範圍</returns>
        public bool AttackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(attackOffset), attackSize, 0, layerTarget);
            return hit;
        }
    }
}