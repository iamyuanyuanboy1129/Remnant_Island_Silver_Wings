using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TwoD
{

    public class PlayerStatBar : MonoBehaviour
    {
        [Header("當前血條")]
        public Image healthImage;
        [Header("傷害延遲血條")]
        public Image healthDelayImage;
        [Header("血量顯示文字")]
        public TextMesh healthText;

        private void Update()
        {
            if (healthDelayImage.fillAmount > healthImage.fillAmount)
            {
                healthDelayImage.fillAmount -= Time.deltaTime;
            }
        }

        /// <summary>
        /// 接收血量的變更百分比
        /// </summary>
        /// <param name="persentage">百分比: Current/Max</param>
        public void OnHealthChange(float persentage)
        {
            healthImage.fillAmount = persentage;

        }

    }
}
