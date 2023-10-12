using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float findRange = 2f;
    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update()
    {
        AimTarget();
    }

    private void AimTarget()
    {
        weapon.LookAt(target);
    }
}
