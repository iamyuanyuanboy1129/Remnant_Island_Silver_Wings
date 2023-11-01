using Unity.VisualScripting;
using UnityEngine;

namespace TwoD
{

    public class DamageSystem : MonoBehaviour
    {
        public int damage;
        public float attackRange;
        public float attackRate;

        void Start()
        {
        
        }

        void Update()
        {
        
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            other.GetComponent<HealthSystem>()?.TakeDamage(this);
            //print(gameObject.name + "造成傷害");
            //print(other.name);
        }
    }
}   
