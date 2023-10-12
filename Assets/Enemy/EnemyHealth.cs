using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 10;
    int currentHp = 0;
    private void Start()
    {
        currentHp = maxHp;
    }
    private void OnParticleCollision(GameObject other)
    {
        Damaged();
    }

    private void Damaged()
    {
        currentHp--;
        if (currentHp < 0)
            Destroy(gameObject);
    }
}
