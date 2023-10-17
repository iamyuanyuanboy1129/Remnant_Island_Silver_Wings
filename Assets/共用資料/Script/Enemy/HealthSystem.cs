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
        public float invulnerableCounter;
        public bool invulnerable;

        public UnityEvent<HealthSystem> OnHealthChange;

        public UnityEvent<Transform> OnTakeDamage;
        public UnityEvent OnDie;

        private Rigidbody2D rig;
        private Transform player;
        private GameObject gameObject;

        private void Start()
        {
            currentHealth = maxHealth;
            OnHealthChange?.Invoke(this);

            rig = GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player_Idle").transform;
            gameObject = GameObject.Find(this.name);
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
                FlipToPlayer();
            }
            else
            {
                currentHealth = 0;
                rig.velocity = Vector3.zero;
                //觸發死亡
                OnDie?.Invoke();
            }

            OnHealthChange?.Invoke(this);
        }
        public void TakeParticleDamage(float damage)
        {
            if (invulnerable)
                return;

            //Debug.Log(attacker.damage);
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;
                TriggerInvulnerable();
            }
            else
            {
                currentHealth = 0;
                rig.velocity = Vector3.zero;
                //觸發死亡
                OnDie?.Invoke();
            }

            OnHealthChange?.Invoke(this);
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
        /// <summary>
        /// 轉向玩家
        /// </summary>
        private void FlipToPlayer()
        {
            if(player.transform.position.x < transform.position.x)
            {
                gameObject.GetComponent<StateWander>().direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                gameObject.GetComponent<StateWander>().direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }
}
