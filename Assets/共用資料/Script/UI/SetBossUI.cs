using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Timeline;

namespace TwoD
{
    public class SetBossUI : MonoBehaviour
    {
        public Vector3 pointOriginal;
        private AudioManager audioManager;
        private bool isPlaying = false;

        [SerializeField, Header("Boss血條")]
        private GameObject bossHealthBar;
        [SerializeField, Header("Boss名稱")]
        private GameObject bossName;

        [field: SerializeField, Header("目標圖層")]
        protected LayerMask layerTarget { get; private set; }

        [Header("Boss範圍")]
        [SerializeField]
        private Vector3 roomSize = Vector3.one;
        [SerializeField]
        private Vector3 roomOffset;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
            Gizmos.DrawCube(pointOriginal + transform.TransformDirection(roomOffset), roomSize);
        }

        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }
        void Update()
        {
            if (PlayerInRoom())
            {
                print("玩家進入房間");
                bossHealthBar.SetActive(true);
                bossName.SetActive(true);
                if (!isPlaying)
                {
                    isPlaying = true;
                    audioManager.StopBG();
                    audioManager.PlaySFX(audioManager.BossBattle);
                }
            }
            else
            {
                bossHealthBar.SetActive(false);
                bossName.SetActive(false);
            }
        }
        public bool PlayerInRoom()
        {
            Collider2D hit = Physics2D.OverlapBox(pointOriginal + transform.TransformDirection(roomOffset), roomSize, 0, layerTarget);
            return hit;
        }
        [ContextMenu("取得原始座標")]
        private void GetOriginalPoint()
        {
            pointOriginal = transform.position;
        }
    }
}
