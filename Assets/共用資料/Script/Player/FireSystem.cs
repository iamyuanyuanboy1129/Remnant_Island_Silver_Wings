using Fungus;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    /// <summary>
    /// ���������t��
    /// </summary>
    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("�����i�w�s��")]
        private GameObject prefabBullet;
        [SerializeField, Header("�ͦ������i��m")]
        private Transform pointBullet;
        [SerializeField, Header("�o�g�����i�O�D"), Range(0, 2500)]
        private float powerBullet = 1000;

        private Animator ani;

        private string parHolyFire = "Ĳ�o�����i";

        private void Awake()
        {
            ani = GetComponent<Animator>();
       }

        private void Update()
        {
            HolyFire();
        }
        /// <summary>
        /// �����i����
        /// </summary>
        private void HolyFire()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                ani.SetTrigger(parHolyFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * powerBullet);

            }
        }
    }
}
