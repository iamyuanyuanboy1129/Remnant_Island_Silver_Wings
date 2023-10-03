using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    public class TrapStateManagerAlwaysTrigger : MonoBehaviour
    {
        [field: SerializeField, Header("目標圖層")]
        protected LayerMask layerTarget { get; private set; }
        [SerializeField, Header("冷卻時間"), Range(0, 3)]
        public float cooldownTime;


        private Animator ani;
        private string isTrigger = "isTrigger";
        private float timer;

        // Start is called before the first frame update
        void Start()
        {
            ani = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                ani.SetTrigger(isTrigger);
                timer = 0;
            }
        }
    }
}
