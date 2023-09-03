using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class HealthSystem : MonoBehaviour
    {
        [Header("基本屬性")]
        [SerializeField] public float maxHealth;
        [SerializeField] public float currentHealth;

        [Header("受傷無敵")]
        public float invulnerableDuration;
        private float invulnerableCounter;
        public bool invulnerable;

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
            }
            else
            {
                currentHealth = 0;
                //觸發死亡
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
