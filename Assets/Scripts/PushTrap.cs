using UnityEngine;

public class PushTrap : Trap
{
    public float PushForce = 5f;

    public override void TriggerEffect(Collider2D collider)
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            rb.AddForce(direction * PushForce, ForceMode2D.Impulse);
        }
    }
}
