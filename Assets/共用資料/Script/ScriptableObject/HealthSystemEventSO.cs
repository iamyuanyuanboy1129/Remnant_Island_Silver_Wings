using UnityEngine;
using UnityEngine.Events;

namespace TwoD
{

    [CreateAssetMenu(fileName = "Event/HealthSystemEventSO")]
    public class HealthSystemEventSO : ScriptableObject
    {
        public UnityAction<HealthSystem> OnEventRaised;

        public void ResetEvent(HealthSystem healthSystem)
        {
            OnEventRaised?.Invoke(healthSystem);
        }
    }
}
