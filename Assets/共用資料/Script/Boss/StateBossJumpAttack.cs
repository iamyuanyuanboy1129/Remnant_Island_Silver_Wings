using System.Collections;
using UnityEngine;

namespace TwoD
{

    public class StateBossJumpAttack : State
    {
        [SerializeField, Header("跳躍力道x"), Range(0, 5000)]
        private float jumpForceX = 50f;
        [SerializeField, Header("跳躍力道y"), Range(0, 5000)]
        private float jumpForceY = 500f;

        public StateBossTrack bossTrack;

        private Rigidbody2D rig;
        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }
        public override State RunCurrentState()
        {
            JumpAttack();
            return bossTrack;
        }
        private void JumpAttack()
        {
            rig.AddForce(new Vector2(jumpForceX * bossTrack.direction, jumpForceY));
            ani.SetTrigger("觸發跳躍攻擊");
        }
    }
}
