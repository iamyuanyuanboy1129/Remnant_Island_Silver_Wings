using UnityEngine;

namespace TwoD
{
    /// <summary>
    /// 狀態管理
    /// </summary>
    public class StateManager : MonoBehaviour
    {
        [SerializeField, Header("預設狀態")]
        private State stateDefault;

        private bool isAttack;

        private Animator ani;
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            RunStateMachine();
        }

        private void RunStateMachine()
        {
            State nextState = stateDefault?.RunCurrentState();

            if (nextState != null)
            {
                stateDefault = nextState;
            }
        }
        public void EnemyHurt()
        {
            if (gameObject.CompareTag("Boss"))
            {
                isAttack = GetComponent<StateBossCloseAttack>().isAttack;
                if (!isAttack)
                {
                    ani.SetTrigger("觸發受傷");
                }
            }
            else
            {
                ani.SetTrigger("觸發受傷");
            }
        }
        public void EnemyDead()
        {
            ani.SetBool("開關死亡", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            //GameObject.Find(this.name).GetComponent<StateManager>().enabled = false;
            this.GetComponent<StateManager>().enabled = false;
        }
    }
}
