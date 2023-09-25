using UnityEngine;

namespace TwoD
{
    public class SetVelocityToZero : MonoBehaviour
    {
        GameObject gameObject;
        Rigidbody2D rig;
        Animator air;
        

        void Start()
        {
            rig = this.GetComponent<Rigidbody2D>();
            air = this.GetComponent<Animator>();
        }

        void Update()
        {

        }

        public void SetV2Z()
        {
            rig.velocity = Vector3.zero;
            air.SetBool("isRun", false);

        }

    }
}
