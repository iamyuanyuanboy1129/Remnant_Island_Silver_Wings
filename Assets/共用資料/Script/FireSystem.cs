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

        [Header("����&�����ˮ`��")]
        [SerializeField] public float damageNomalFire = 20.0f;
        [SerializeField] public float damageHolyFire = 80.0f;

        [SerializeField, Header("�Ĥ@�q�����ϰ�")]
        private Transform Attack_area_one;
        [SerializeField, Header("�ĤG�q�����ϰ�")]
        private Transform Attack_area_two;

        private Animator ani;
        private PolygonCollider2D pcollider;

        private string parHolyFire = "Ĳ�o�����i";
        private string parNomalFire = "Ĳ�o���q����";
        public float time_one = 1.5f;
        public float time_two = 2.5f;
        public float startTime;


        private void Awake()
        {
            ani = GetComponent<Animator>();
            pcollider = GameObject.FindGameObjectWithTag("Attack_area").GetComponent<PolygonCollider2D>();
        }

        private void Update()
        {
            HolyFire();
            NormalAttack();
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

        private void NormalAttack()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                pcollider.enabled = true;
                ani.SetTrigger(parNomalFire);
                StartCoroutine(StartAttack());
            }
        }

        IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(startTime);
            pcollider.enabled = true;
            StartCoroutine(disableHitBox());
        }

        IEnumerator disableHitBox()
        {
            yield return new WaitForSeconds(time_one);
            pcollider.enabled = false;
        }
    }
}
