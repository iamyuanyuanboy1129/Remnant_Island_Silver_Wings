using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class HidingObject : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            collision.GetComponent<Player>().canHide = true;
        }
    }

}
