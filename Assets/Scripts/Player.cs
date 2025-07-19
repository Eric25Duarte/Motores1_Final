using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField]
    private float _health = 100f;
    public float MaxHealth { get; private set; } = 100f;

    public BasicWeapon Weapon;

    public static Player Instance { get; private set; }

    // Evento de morte do jogador
    public static event Action OnPlayerDeath;
    // Evento de cura
    public event Action<float> OnHeal;

    public float CurrentHealth => _health;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject); 
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Weapon.Shoot();
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        OnPlayerDeath?.Invoke();
        // Handle player death.
    }

    public void Heal(float amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0f, MaxHealth);
        OnHeal?.Invoke(amount);
    }

    public float GetHealth()
    {
        return _health;
    }
}
