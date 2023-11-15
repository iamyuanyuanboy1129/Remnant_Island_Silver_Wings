using UnityEngine;

namespace TwoD
{
    public class SetHolyCount : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameObject.Find("Player_Idle").GetComponent<FireSystem>().holyCount = 2;          
            }
        }
    }
}
