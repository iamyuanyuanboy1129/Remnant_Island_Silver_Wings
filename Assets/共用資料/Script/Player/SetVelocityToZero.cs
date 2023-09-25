using System.Collections;
using System.Collections.Generic;
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
            gameObject = GameObject.Find("Player_Idle");
            rig = gameObject.GetComponent<Rigidbody2D>();
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
