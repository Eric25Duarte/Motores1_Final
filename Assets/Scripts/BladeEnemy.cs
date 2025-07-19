using UnityEngine;

public class BladeEnemy : Enemy
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float collisionDamage = 10f;

    protected override void Move()
    {
        Debug.Log("BladeEnemy is chasing the player.");
    }

    private void Update()
    {
        base.UpdatePosition();
        RotateBlades();
    }

    private void RotateBlades()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Prevent parent from being destroyed by collisions with blades
        if (collision.gameObject.layer == LayerMask.NameToLayer("Blade"))
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out IHealth player))
            {
                player.TakeDamage(collisionDamage);
            }
        }
    }
}
