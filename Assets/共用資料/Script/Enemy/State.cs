using UnityEngine;

namespace TwoD
{
    /// <summary>
    /// 狀態抽象類別
    /// </summary>
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// 執行當前的狀態
        /// </summary>
        /// <returns>當前的狀態</returns>
        public abstract State RunCurrentState();

        /// <summary>
        /// 動畫控制元件 (唯讀)
        /// </summary>
        protected Animator ani { get; private set; }

        [field:SerializeField, Header("目標圖層")]
        protected LayerMask layerTarget {get; private set;}

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }
}
