using UnityEngine;

public class HealingPowerUp : PowerUp
{
    public float HealAmount = 25f;

    public override void Activate(Player player)
    {
        player.Heal(HealAmount);
        Destroy(gameObject);
    }
}
