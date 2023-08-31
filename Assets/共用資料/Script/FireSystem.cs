using Fungus;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    /// <summary>
    /// 神器攻擊系統
    /// </summary>
    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("衝擊波預製物")]
        private GameObject prefabBullet;
        [SerializeField, Header("生成衝擊波位置")]
        private Transform pointBullet;
        [SerializeField, Header("發射衝擊波力道"), Range(0, 2500)]
        private float powerBullet = 1000;

        [Header("普攻&神器傷害值")]
        [SerializeField] private float damageNomalFire = 20.0f;
        [SerializeField] private float damageHolyFire = 80.0f;
        [Header("主角攻擊判斷區域")]
        [SerializeField]
        private Vector3 idleAttackSize_one = Vector3.one;
        [SerializeField]
        private Vector3 idleAttackOffset_one;
        [SerializeField]
        private Vector3 idleAttackSize_two = Vector3.one;
        [SerializeField]
        private Vector3 idleAttackOffset_two;

        [SerializeField, Header("送出攻擊1檢測的時間點"), Range(0, 5)]
        private float idleAttackTimeCheck_one = 0.2f;
        [SerializeField, Header("送出攻擊2檢測的時間點"), Range(0, 5)]
        private float idleAttackTimeCheck_two = 0.6f;
        [SerializeField, Header("攻擊結束的時間點"), Range(0, 5)]
        private float idleAttackTimeEnd = 0.8f;
        [field: SerializeField, Header("攻擊圖層")]
        protected LayerMask layerTarget { get; private set; }

        private Animator ani;
        private string parHolyFire = "觸發衝擊波";
        private string parNomalFire = "觸發普通攻擊";
        //private float timer;


        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.7f, 0.9f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(idleAttackOffset_one), idleAttackSize_one);
            Gizmos.color = new Color(1, 0.7f, 0.1f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(idleAttackOffset_two), idleAttackSize_two);
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            HolyFire();
            NormalFire();
        }
        /// <summary>
        /// 衝擊波攻擊
        /// </summary>
        private void HolyFire()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                ani.SetTrigger(parHolyFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * powerBullet);
            }
        }
        /// <summary>
        /// 普通攻擊
        /// </summary>
        private void NormalFire()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                //if (timer == 0)
                //{
                    ani.SetTrigger(parNomalFire);
                //}
                /*
                else
                {
                    if (timer == idleAttackTimeCheck_one || timer == idleAttackTimeCheck_two)
                    {
                        if (AttackRange_one() || AttackRange_two())
                        {
                            
                            print("<color=#69f>擊中</color>");

                        }
                    }
                    else if (timer >= idleAttackTimeEnd)
                    {

                        timer = 0;

                    }
                }
                */

                //timer += Time.deltaTime;


            }
        }
        /// <summary>
        /// 攻擊目標碰撞檢測
        /// </summary>
        /// <returns>是否有目標進入範圍</returns>
        /*
        public bool AttackRange_one()
        {
            print("123");

            Collider2D hit_one = Physics2D.OverlapBox(transform.position + transform.TransformDirection(idleAttackOffset_one), idleAttackSize_one, 0, layerTarget);
            return hit_one;
        }
        public bool AttackRange_two()
        {
            print("456");

            Collider2D hit_two = Physics2D.OverlapBox(transform.position + transform.TransformDirection(idleAttackOffset_two), idleAttackSize_two, 0, layerTarget);
            return hit_two;
        }
        */
    }
}
