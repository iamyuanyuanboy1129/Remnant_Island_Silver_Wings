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
        [SerializeField] public float damageNomalFire = 20.0f;
        [SerializeField] public float damageHolyFire = 80.0f;

        [SerializeField, Header("第一段攻擊區域")]
        private Transform Attack_area_one;
        [SerializeField, Header("第二段攻擊區域")]
        private Transform Attack_area_two;

        private Animator ani;
        private PolygonCollider2D pcollider;

        private string parHolyFire = "觸發衝擊波";
        private string parNomalFire = "觸發普通攻擊";
        public float time_one = 1.5f;
        public float time_two = 2.5f;
        public float startTime;


        private void Awake()
        {
            ani = GetComponent<Animator>();
            pcollider = GameObject.FindGameObjectWithTag("Attack_area").GetComponent<PolygonCollider2D>();
        }

        private void Update()
        {
            HolyFire();
            NormalAttack();
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

        private void NormalAttack()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                pcollider.enabled = true;
                ani.SetTrigger(parNomalFire);
                StartCoroutine(StartAttack());
            }
        }

        IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(startTime);
            pcollider.enabled = true;
            StartCoroutine(disableHitBox());
        }

        IEnumerator disableHitBox()
        {
            yield return new WaitForSeconds(time_one);
            pcollider.enabled = false;
        }
    }
}
