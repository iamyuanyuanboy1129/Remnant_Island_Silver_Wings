using UnityEngine;

namespace TwoD
{
    /// <summary>
    /// 衝擊波
    /// </summary>
    public class Bullet : MonoBehaviour
    {



        private void Awake()
        {
            Destroy(gameObject, 3);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //print($"碰到的物件 : {collision.gameObject}");
            Destroy(gameObject);
        }

    }
}
