using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace TwoD
{
    public class HealthSystem : MonoBehaviour
    {
        [Header("基本屬性")]
        [SerializeField, Header("最大血量")] public float maxHealth;
        [SerializeField, Header("當前血量")] public float currentHealth;

        [Header("受傷無敵")]
        public float invulnerableDuration;
        private float invulnerableCounter;
        public bool invulnerable;

        public UnityEvent<Transform> OnTakeDamage;
        public UnityEvent OnDie;


        private void Start()
        {
            currentHealth = maxHealth;

        }

        private void Update()
        {
            if (invulnerable)
            {
                invulnerableCounter -= Time.deltaTime;
                if (invulnerableCounter <= 0)
                {
                    invulnerable = false;
                }
            }
        }

        public void TakeDamage(DamageSystem attacker)
        {
            if (invulnerable)
                return;

            //Debug.Log(attacker.damage);
            if (currentHealth - attacker.damage > 0)
            {
                currentHealth -= attacker.damage;
                TriggerInvulnerable();
                //執行受傷
                OnTakeDamage?.Invoke(attacker.transform);
            }
            else
            {
                currentHealth = 0;
                //觸發死亡
                OnDie?.Invoke();
            }
        }

        /// <summary>
        /// 觸發受傷無敵
        /// </summary>
        private void TriggerInvulnerable()
        {
            if (!invulnerable)
            {
                invulnerable = true;
                invulnerableCounter = invulnerableDuration;
            }
        }

    }
}
