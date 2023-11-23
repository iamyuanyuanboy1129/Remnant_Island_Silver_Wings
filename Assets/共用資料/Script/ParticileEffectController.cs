using UnityEngine;

public class ParticileEffectController : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        float lifeTime = ps.main.duration;
        Destroy(gameObject, lifeTime);
    }
}
