using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    public float ShieldDuration = 5f;

    public override void Activate(Player player)
    {
        Debug.Log("Shield activated for " + ShieldDuration + " seconds.");
        // Implement shield logic.
        Destroy(gameObject);
    }
}
