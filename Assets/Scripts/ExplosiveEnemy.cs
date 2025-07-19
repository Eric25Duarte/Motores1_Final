using UnityEngine;

public class ExplosiveEnemy : Enemy
{
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private float explosionDamage = 20f;

    protected override void Move()
    {
        Debug.Log("ExplosiveEnemy is moving toward the target.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tower"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("ExplosiveEnemy exploded!");
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IHealth target))
            {
                target.TakeDamage(explosionDamage);
            }
        }

        Destroy(gameObject);
    }
}
