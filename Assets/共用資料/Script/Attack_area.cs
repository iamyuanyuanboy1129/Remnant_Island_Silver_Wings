using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{ 
    public class Attack_area : MonoBehaviour
    {

        private string parNomalFire = "Ä²µo´¶³q§ðÀ»";

        public float time;
        public float startTime;

        private Animator ani;
        private PolygonCollider2D pcollider;

        void Start()
        {
            ani = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            pcollider = GetComponent<PolygonCollider2D>();  
        }


        void Update()
        {
            Attack();
        }

        void Attack()
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
            yield return new WaitForSeconds(time);
            pcollider.enabled = false;
        }
    }
}

