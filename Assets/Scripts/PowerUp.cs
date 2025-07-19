using System;
using UnityEngine;

public interface IPowerUp
{
    void Activate(Player player);
}

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public abstract void Activate(Player player);

    public float Life_Time { get; set; } = 3f;

    public event Action<Player> OnPowerUpActivated;

    public void Start()
    {
        Destroy(gameObject, Life_Time);
    }

    public void ApplyEffect(Player player, Tower Tower)
    {
        // Apply Power Up Effect
    }

    public void UpChase(Player Player)
    {
        // Future logic
    }

    protected void NotifyActivated(Player player)
    {
        OnPowerUpActivated?.Invoke(player);
    }
}
