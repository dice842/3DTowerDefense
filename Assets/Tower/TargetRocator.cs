using UnityEngine;

public class TargetRocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float findRange = 2f;

    ParticleSystem weaponParticle;
    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        if (weaponParticle != null)
            weaponParticle.Stop();
    }
    private void Update()
    {
        FindClosestTarget();
        AimTarget();
    }
    private void FindClosestTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, findRange);

        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider hitCollider in hitColliders)
        {
            EnemyMover enemy = hitCollider.GetComponentInParent<EnemyMover>();

            if (enemy == null)
            {
                continue;
            }

            float targetDistance =
                Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < closestDistance)
            {
                closestTarget = enemy.transform;
                closestDistance = targetDistance;
            }
        }

        target = closestTarget;
    }
    private void AimTarget()
    {
        weapon.LookAt(target);
    }
}
