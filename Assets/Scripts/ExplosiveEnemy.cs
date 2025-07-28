using UnityEngine;

public class ExplosiveEnemy : Enemy
{
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private float explosionDamage = 20f;
    [SerializeField] private GameObject explosionPrefab;

    protected override void Move()
    {
        Debug.Log("ExplosiveEnemy is moving toward the target.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tower"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
