using UnityEngine;

namespace TwoD
{
    /// <summary>
    /// 神器攻擊系統
    /// </summary>
    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("衝擊波預製物")]
        private GameObject prefabBullet;
        [SerializeField, Header("生成衝擊波位置")]
        private Transform pointBullet;
        [SerializeField, Header("發射衝擊波力道"), Range(0, 2500)]
        private float powerBullet = 1000;

        private Animator ani;
        private string parFire = "觸發衝擊波";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Fire();
        }
        /// <summary>
        /// 衝擊波攻擊
        /// </summary>
        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ani.SetTrigger(parFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * powerBullet);
            }
        }
        
    }
}
