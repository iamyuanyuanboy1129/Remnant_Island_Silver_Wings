using UnityEngine;

namespace TwoD
{
    public class PlayerParticleDamageSystem : MonoBehaviour
    {
        [SerializeField, Header("火球傷害"), Range(0, 100)]
        private float fireDamage;

        private HealthSystem healthSystem;
        void Start()
        {
            healthSystem = GetComponent<HealthSystem>();
        }

        void Update()
        {

        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("FireBall"))
            {
                healthSystem.TakeParticleDamage(fireDamage);
            }
        }
    }
}
