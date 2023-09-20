using Fungus;
using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
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
        [SerializeField, Header("衝擊波延遲發射時間")]
        private float waitingSec = 1.5f;
        [SerializeField, Header("神劍攻擊次數")]
        private int holyCount = 2;
        [SerializeField, Header("第一段攻擊時間"), Range(0, 1)]
        private float firstAttackTime = 0.3f;

        private Animator ani;

        private string parHolyFire = "觸發衝擊波";
        private string parNormalFire = "觸發普通攻擊";
        public bool isAttack = false;
        public bool canHolyFire = true;

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
            if (Input.GetKeyDown(KeyCode.C) && canHolyFire && holyCount > 0)
            {
                holyCount--;
                canHolyFire = false;
                ani.SetTrigger(parHolyFire);

                StartCoroutine(Waiting());
            }
        }
        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(waitingSec);

            GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * powerBullet);
            canHolyFire = true;
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
                this.GetComponent<Player>().isAttack = isAttack;
                ani.SetTrigger(parNormalFire);

                if (!this.GetComponent<Player>().movementEnable)
                {
                    //隱藏後攻擊，解除隱藏狀態
                    GetComponent<Player>().movementEnable = true;
                    GetComponent<CapsuleCollider2D>().excludeLayers = LayerMask.GetMask("Nothing");
                    GetComponent<HealthSystem>().invulnerable = false;
                    GetComponent<HealthSystem>().invulnerableCounter = 0f;
                    GetComponent<Player>().player.layer = LayerMask.NameToLayer("player");
                    //隱藏後攻擊上升
                    gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                    GetComponentInChildren<DamageSystem>().damage += 100;
                    StartCoroutine(WaitFirstAttack());
                }
            }
        }
        IEnumerator WaitFirstAttack()
        {
            yield return new WaitForSeconds(firstAttackTime);
            GetComponentInChildren<DamageSystem>().damage -= 100;
        }
    }
}
