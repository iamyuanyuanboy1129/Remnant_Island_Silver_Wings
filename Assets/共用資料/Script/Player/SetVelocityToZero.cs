using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TwoD
{
    public class SetVelocityToZero : MonoBehaviour
    {
        GameObject gameObject;
        Rigidbody2D rig;
        // Start is called before the first frame update
        void Start()
        {
            rig = this.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetV2Z()
        {
            rig.velocity = Vector3.zero;
        }
    }
}
