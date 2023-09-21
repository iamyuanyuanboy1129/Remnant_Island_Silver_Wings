using System;
using UnityEngine;

namespace TwoD
{
    

    public class UIManager : MonoBehaviour
    {
        public PlayerStatBar playerStatBar;

        [Header("事件監聽")]
        public HealthSystemEventSO healthEvent;

        private void OnEnable()
        {
            healthEvent.OnEventRaised += OnHealthEvent;
        }

        private void OnDisable()
        {
            healthEvent.OnEventRaised -= OnHealthEvent;

        }

        private void OnHealthEvent(HealthSystem healthSystem)
        {
            var persentage = healthSystem.currentHealth / healthSystem.maxHealth;
            playerStatBar.OnHealthChange(persentage);
        }

    }
}
