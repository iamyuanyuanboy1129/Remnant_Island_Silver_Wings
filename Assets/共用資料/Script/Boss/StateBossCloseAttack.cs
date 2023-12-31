﻿using System.Collections;
using UnityEngine;

namespace TwoD
{

    public class StateBossCloseAttack : State
    {
        
        private float atkCDTime = 1.5f;

        private float atkType;
        private string parLitAtk = "觸發輕攻擊";
        private string parCharge = "觸發續力";
        private string parHardAtk = "觸發重攻擊";
        private string parWalk = "開關走路";
        private string parRun = "開關跑步";
        private float rdt = 0;
        private float timer = 0;
        private float blockChance = 0;
        public bool canBlock = true;

        public bool isAttack = false;

        public StateBossTrack bossTrack;
        public StateBossBlock bossBlock;

        public override State RunCurrentState()
        {
            //print("攻擊狀態");
            ani.SetBool("開關走路", false);
            ani.SetBool("開關跑步", false);
            if (Input.GetKeyDown(KeyCode.V) && canBlock)
            {
                blockChance = Random.Range(0, 11);
                if (blockChance > 8)
                {
                    canBlock = false;
                    return bossBlock;
                }
            }
            if (bossTrack.TriggerCloseAttack() && timer == 0)
            {
                atkType = Random.Range(0, 10);
                //print(atkType);
                if (atkType < 7)
                {
                    ani.SetTrigger(parLitAtk);
                    isAttack = true;
                    atkCDTime = 1.3f;
                }
                else
                {
                    atkCDTime = 1.7f;
                    canBlock = false;
                    isAttack = true;
                    ani.SetTrigger(parCharge);
                    rdt = Random.Range(7, 13);
                    //print(rdt);
                    StartCoroutine(WaitRandomTime(rdt / 10));
                }
            }
            else if (timer >= atkCDTime)
            {
                timer = 0;
                canBlock = true;
                isAttack = false;
                bossTrack.canMove = true;
                return bossTrack;
            }
            timer += Time.deltaTime;
            print(timer);
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
