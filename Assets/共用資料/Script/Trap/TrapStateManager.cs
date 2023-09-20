using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    public class TrapStateManager : MonoBehaviour
    {
        [Header("觸發區域")]
        [SerializeField]
        private Vector3 triggerSize = Vector3.one;
        [SerializeField]
        private Vector3 triggerOffset;
        [field: SerializeField, Header("目標圖層")]
        protected LayerMask layerTarget { get; private set; }
        [SerializeField, Header("冷卻時間"), Range(0, 3)]
        private float cooldownTime;


        private Animator ani;
        private string isTrigger = "isTrigger";
        private float timer;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(triggerOffset), triggerSize);
        }

        // Start is called before the first frame update
        void Start()
        {
            ani = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (AttackTarget()&& timer >= cooldownTime)
            {
                ani.SetTrigger(isTrigger);
                timer = 0;
            }
        }

        /// <summary>
        /// 攻擊目標碰撞檢測
        /// </summary>
        /// <returns>是否有目標進入範圍</returns>
        public bool AttackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(triggerOffset), triggerSize, 0, layerTarget);
            return hit;
        }
    }
}
