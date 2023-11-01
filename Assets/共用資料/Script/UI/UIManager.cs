using System;
using UnityEngine;

namespace TwoD
{
    

    public class UIManager : MonoBehaviour
    {
        public PlayerStatBar playerStatBar;
        public PlayerStatBar bossStatBar;

        [Header("事件監聽")]
        public HealthSystemEventSO healthEvent;
        public HealthSystemEventSO bossHealthEvent;

        private void OnEnable()
        {
            healthEvent.OnEventRaised += OnHealthEvent;
            bossHealthEvent.OnEventRaised += OnBossHealthEvent;
        }

        private void OnDisable()
        {
            healthEvent.OnEventRaised -= OnHealthEvent;
            bossHealthEvent.OnEventRaised -= OnBossHealthEvent;
        }

        private void OnHealthEvent(HealthSystem healthSystem)
        {
            var persentage = healthSystem.currentHealth / healthSystem.maxHealth;
            playerStatBar.OnHealthChange(persentage);
        }
        private void OnBossHealthEvent(HealthSystem healthSystem)
        {
            var persentage = healthSystem.currentHealth / healthSystem.maxHealth;
            bossStatBar.OnHealthChange(persentage);
        }
    }
}
