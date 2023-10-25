using System.Collections;
using UnityEngine;

namespace TwoD
{

    public class StateBossBlock : State
    {
        public StateBossCloseAttack closeAttack;

        private string parBlock = "¶}Ãö®æ¾×";
        private float rdt = 0;
        private HealthSystem healthSystem;
        private void Start()
        {
            healthSystem = GetComponent<HealthSystem>();
        }
        public override State RunCurrentState()
        {
            ani.SetBool(parBlock, true);
            healthSystem.invulnerable = true;
            rdt = Random.Range(5, 16);
            StartCoroutine(BlockTime(rdt / 10));
            return closeAttack;
        }
        IEnumerator BlockTime(float time)
        {
            yield return new WaitForSeconds(time);
            ani.SetBool(parBlock, false);
            healthSystem.invulnerable = false;
        }
    }
}
