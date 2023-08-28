using MoonSharp.Interpreter.CoreLib;
using UnityEngine;

namespace TwoD
{

    public class StateWander : State
    {
        [SerializeField, Header("角色的初始座標")]
        private Vector3 pointOriginal;
        [SerializeField, Header("左邊座標位移")]
        private float offsetLeft = -2;
        [SerializeField, Header("右邊座標位移")]
        private float offsetRight = 2;
        [SerializeField, Header("移動速度"), Range(0, 5)]
        private float speed = 1.5f;

        private string parWalk = "開關走路";
        private Rigidbody2D rig;
        /// <summary>
        /// 方向 : 右邊+1  左邊-1
        /// </summary>
        public int direction = 1;

        private Vector3 pointLeft => pointOriginal + Vector3.right * offsetLeft;
        private Vector3 pointRight => pointOriginal + Vector3.right * offsetRight;

        [SerializeField, Header("等待狀態")]
        private StateIdle stateIdle;
        [SerializeField, Header("是否開始等待")]
        private bool startIdle;
        [SerializeField, Header("等待狀態的隨機時間範圍")]
        private Vector2 rangeWanderTime = new Vector2(0, 10);

        [Header("追蹤區域資料")]
        [SerializeField]
        private Vector3 trackSize = Vector3.one;
        [SerializeField]
        private Vector3 trackOffset;

        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;

        private float timeWander;
        private float timer;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
            Gizmos.DrawSphere(pointLeft, 0.1f);
            Gizmos.DrawSphere(pointRight, 0.1f);

            Gizmos.color = new Color(1, 0.8f, 0.5f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(trackOffset), trackSize);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            timeWander = Random.Range(rangeWanderTime.x, rangeWanderTime.y);
        }

        public override State RunCurrentState()
        {
            MoveAndFlip();

            timer += Time.deltaTime;
            //print($"<color=#d69>計時器 : {timer}</color>");

            if (timer >= timeWander) startIdle = true;

            if (TrackTarget())
            {
                ResetState();
                return stateTrack;
            }
            else if (startIdle)
            {
                ResetState();
                return stateIdle;
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 追蹤目標物件
        /// </summary>
        /// <returns>是否有追蹤物件進入區域</returns>
        public bool TrackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(trackOffset), trackSize, 0, layerTarget);
            
            if (!hit) return false;

            if (hit.transform.position.x > pointLeft.x && hit.transform.position.x < pointRight.x) return hit;

            return false;
        }

        /// <summary>
        /// 重設狀態資料
        /// </summary>
        private void ResetState()
        {
            timer = 0;
            startIdle = false;
            timeWander = Random.Range(rangeWanderTime.x, rangeWanderTime.y);
            rig.velocity = Vector3.zero;

            ani.SetBool(parWalk, false);
        }
        /// <summary>
        /// 移動與翻面
        /// </summary>
        private void MoveAndFlip()
        {
            if (Vector3.Distance(transform.position, pointRight) < 0.1f)
            {
                direction = -1;
                //transform.eulerAngles = Vector3.zero;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Vector3.Distance(transform.position, pointLeft) < 0.1f)
            {
                direction = 1;
                //transform.eulerAngles = new Vector3(0, 180, 0);
                transform.eulerAngles = Vector3.zero;
            }

            rig.velocity = new Vector2(direction * speed, rig.velocity.y);
            ani.SetBool(parWalk, true);
        }

        [ContextMenu("取得角色原始座標")]
        private void GetOriginalPoint()
        {
            pointOriginal = transform.position;
        }
    }
}
