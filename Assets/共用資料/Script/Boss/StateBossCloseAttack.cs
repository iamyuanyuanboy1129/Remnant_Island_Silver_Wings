using System.Collections;
using UnityEngine;

namespace TwoD
{

    public class StateBossCloseAttack : State
    {
        [SerializeField, Header("攻擊時間間距")]
        private float atkCDTime = 1.5f;

        private float atkType;
        private string parLitAtk = "觸發輕攻擊";
        private string parCharge = "觸發續力";
        private string parHardAtk = "觸發重攻擊";
        private float rdt = 0;
        private float timer = 0;

        public StateBossTrack bossTrack;

        public override State RunCurrentState()
        {
            ani.SetBool("開關走路", false);
            ani.SetBool("開關跑步", false);
            if (bossTrack.TriggerCloseAttack() && timer == 0)
            {
                atkType = Random.Range( 0, 10);
                //print(atkType);
                if (atkType < 7)
                {
                    ani.SetTrigger(parLitAtk);
                }
                else
                {
                    ani.SetTrigger(parCharge);
                    rdt = Random.Range(5, 10);
                    //print(rdt);
                    StartCoroutine(WaitRandomTime(rdt/10));
                }
            }
            else if(timer >= atkCDTime)
            {
                timer = 0;
                return bossTrack;
            }
            timer += Time.deltaTime;
            return this;
        }
        IEnumerator WaitRandomTime(float rt)
        {
            yield return new WaitForSeconds(rt);
            ani.SetTrigger(parHardAtk);
            //print("atkTrigger!");
        }
    }
}
