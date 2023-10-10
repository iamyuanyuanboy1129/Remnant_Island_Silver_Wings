using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttack : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        print(other.name);
    }
}
