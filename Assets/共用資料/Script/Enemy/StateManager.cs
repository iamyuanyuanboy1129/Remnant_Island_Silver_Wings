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
    }
}
