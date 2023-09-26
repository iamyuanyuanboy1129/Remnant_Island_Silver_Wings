using UnityEngine;

namespace TwoD
{
    public class SetVelocityToZero : MonoBehaviour
    {
        GameObject gameObject;
        Rigidbody2D rig;
        Animator ani;
        
        void Start()
        {
            rig = this.GetComponent<Rigidbody2D>();
            ani = this.GetComponent<Animator>();

        }

        void Update()
        {

        }

        public void SetV2Z()
        {
            rig.velocity = Vector3.zero;

            ani.SetBool("isRun", false);
            ani.SetBool("isJump", false);

        }

    }
}
