using Cinemachine;
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

        private CinemachineImpulseSource impulseSource;
        private Rigidbody2D rig;
        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            impulseSource = FindObjectOfType<CinemachineImpulseSource>();
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
            StartCoroutine(WaitForImpulse());
        }
        IEnumerator WaitForImpulse()
        {
            yield return new WaitForSeconds(0.6f);
            impulseSource.GenerateImpulse();
        }
    }
}
