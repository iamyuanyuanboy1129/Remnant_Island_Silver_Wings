using UnityEngine;

namespace TwoD
{
    /// <summary>
    /// 攻擊狀態 :　攻擊完成後回到追蹤狀態
    /// </summary>
    public class StateAttack : State
    {
        [SerializeField, Header("送出攻擊檢測的時間點"), Range(0, 5)]
        private float timeSendAttackCheck = 0.8f;
        [SerializeField, Header("攻擊結束的時間點"), Range(0, 5)]
        private float timeAttackEnd = 1.7f;
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;
        [SerializeField, Header("攻擊速度"), Range(1, 3)]
        public float aniSpeed = 1.5f;


        private string parAttack = "觸發攻擊";
        private float timer;
        private bool canSendAttack = true;

        public override State RunCurrentState()
        {
            if (timer == 0)
            {
                ani.SetTrigger(parAttack);
                if( this.name == "Enemy_Boss")
                    ani.speed = aniSpeed;
            }
            else
            {
                if (timer >= timeSendAttackCheck && canSendAttack)
                {
                    canSendAttack = false;
                    if (stateTrack.AttackTarget())
                    {
                        print("<color=#69f>擊中玩家</color>");
                    }
                }
                else if (timer >= timeAttackEnd)
                {
                    canSendAttack = true;
                    timer = 0;
                    if (this.name == "Enemy_Boss")
                        ani.speed = 1;
                    return stateTrack;
                }
            }

            timer += Time.deltaTime;
            
            return this;
        }
    }
}
