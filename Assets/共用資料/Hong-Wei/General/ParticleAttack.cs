using Fungus;
using System.Collections;
using System.Collections.Generic;
using TwoD;
using UnityEngine;

public class ParticleAttack : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"<color=red>{other.name}</color>");
    }
}
