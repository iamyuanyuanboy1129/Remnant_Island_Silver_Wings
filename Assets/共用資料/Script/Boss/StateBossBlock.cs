using System.Collections;
using UnityEngine;

namespace TwoD
{

    public class StateBossBlock : State
    {
        public StateBossCloseAttack closeAttack;
        public StateBossTrack bossTrack;

        private string parBlock = "開關格擋";
        private float rdt = 0;
        private HealthSystem healthSystem;
        private void Start()
        {
            healthSystem = GetComponent<HealthSystem>();
        }
        public override State RunCurrentState()
        {
            print("格擋狀態");
            ani.SetBool(parBlock, true);
            bossTrack.canMove = false;
            gameObject.GetComponent<StateBossCloseAttack>().enabled = false;
            healthSystem.invulnerable = true;
            healthSystem.invulnerableCounter = 10;
            rdt = Random.Range(5, 16);
            StartCoroutine(BlockTime(rdt / 10));
            return closeAttack;
        }
        IEnumerator BlockTime(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<StateBossCloseAttack>() .enabled = true;
            ani.SetBool(parBlock, false);
            bossTrack.canMove = true;
            healthSystem.invulnerable = false;
            healthSystem.invulnerableCounter = 0;
            closeAttack.canBlock = true;
            print("結束無敵時間！");
        }
    }
}
