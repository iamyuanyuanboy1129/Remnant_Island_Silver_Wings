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
        [SerializeField] private float damageNomalFire = 20.0f;
        [SerializeField] private float damageHolyFire = 80.0f;
        [Header("�D�������P�_�ϰ�")]
        [SerializeField]
        private Vector3 idleAttackSize_one = Vector3.one;
        [SerializeField]
        private Vector3 idleAttackOffset_one;
        [SerializeField]
        private Vector3 idleAttackSize_two = Vector3.one;
        [SerializeField]
        private Vector3 idleAttackOffset_two;

        [SerializeField, Header("�e�X����1�˴����ɶ��I"), Range(0, 5)]
        private float idleAttackTimeCheck_one = 0.2f;
        [SerializeField, Header("�e�X����2�˴����ɶ��I"), Range(0, 5)]
        private float idleAttackTimeCheck_two = 0.6f;
        [SerializeField, Header("�����������ɶ��I"), Range(0, 5)]
        private float idleAttackTimeEnd = 0.8f;
        [field: SerializeField, Header("�����ϼh")]
        protected LayerMask layerTarget { get; private set; }

        private Animator ani;
        private string parHolyFire = "Ĳ�o�����i";
        private string parNomalFire = "Ĳ�o���q����";
        //private float timer;


        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.7f, 0.9f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(idleAttackOffset_one), idleAttackSize_one);
            Gizmos.color = new Color(1, 0.7f, 0.1f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(idleAttackOffset_two), idleAttackSize_two);
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            HolyFire();
            NormalFire();
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
        /// <summary>
        /// ���q����
        /// </summary>
        private void NormalFire()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                //if (timer == 0)
                //{
                    ani.SetTrigger(parNomalFire);
                //}
                /*
                else
                {
                    if (timer == idleAttackTimeCheck_one || timer == idleAttackTimeCheck_two)
                    {
                        if (AttackRange_one() || AttackRange_two())
                        {
                            
                            print("<color=#69f>����</color>");

                        }
                    }
                    else if (timer >= idleAttackTimeEnd)
                    {

                        timer = 0;

                    }
                }
                */

                //timer += Time.deltaTime;


            }
        }
        /// <summary>
        /// �����ؼиI���˴�
        /// </summary>
        /// <returns>�O�_���ؼжi�J�d��</returns>
        /*
        public bool AttackRange_one()
        {
            print("123");

            Collider2D hit_one = Physics2D.OverlapBox(transform.position + transform.TransformDirection(idleAttackOffset_one), idleAttackSize_one, 0, layerTarget);
            return hit_one;
        }
        public bool AttackRange_two()
        {
            print("456");

            Collider2D hit_two = Physics2D.OverlapBox(transform.position + transform.TransformDirection(idleAttackOffset_two), idleAttackSize_two, 0, layerTarget);
            return hit_two;
        }
        */
    }
}
