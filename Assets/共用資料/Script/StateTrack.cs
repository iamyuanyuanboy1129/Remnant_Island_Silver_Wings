using UnityEngine;

namespace TwoD
{

    public class StateTrack : State
    {
        [SerializeField, Header("追蹤速度"), Range(0, 5)]
        private float speed = 1.5f;
        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;

        private Rigidbody2D rig;
        private string parWalk = "開關走路";

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        public override State RunCurrentState()
        {
            if (stateWander.TrackTarget())
            {
                ani.SetBool(parWalk, true);
                ani.speed = 5;
                rig.velocity = new Vector2(speed * stateWander.direction, rig.velocity.y);

                return this;
            }
            else
            {
                ResetState();
                return stateWander;
            }
        }
        /// <summary>
        /// 重設狀態資料
        /// </summary>
        private void ResetState()
        {
            ani.SetBool(parWalk, false);
            ani.speed = 1f;
            rig.velocity = Vector2.zero;
        }
    }
}