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

        private Animator ani;

        private string parHolyFire = "觸發衝擊波";
        private string parNormalFire = "觸發普通攻擊";
        public bool isAttack = false;

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
        public void HolyFire()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                ani.SetTrigger(parHolyFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * powerBullet);

            }
        }
        /// <summary>
        /// 普通二段攻擊
        /// </summary>
        public void NormalFire()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                isAttack = true;
                ani.SetBool("isAttack", true);
                ani.SetTrigger(parNormalFire);
            }
        }
    }
}
