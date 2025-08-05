using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [Header("Health Settings")]
    [SerializeField]
    private float _health = 100f;
    [SerializeField]
    private float _maxHealth = 100f;

    [Header("Shield Settings")]
    [SerializeField]
    private float _shield = 0f;
    [SerializeField]
    private float _maxShield = 50f;
    private float _currentShieldTime = 0f;
    private bool _hasShield = false;

    public BasicWeapon Weapon;

    public static Player Instance { get; private set; }

    // Eventos
    public static event Action OnPlayerDeath;
    public event Action<float> OnHeal;
    public event Action<float> OnShieldChanged;
    public event Action OnShieldActivated;
    public event Action OnShieldDeactivated;

    public float CurrentHealth => _health;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Weapon?.Shoot();
        }

        UpdateShieldTimer();
    }

    private void UpdateShieldTimer()
    {
        if (!_hasShield) return;

        _currentShieldTime -= Time.deltaTime;
        if (_currentShieldTime <= 0)
        {
            DeactivateShield();
        }
    }

    public void TakeDamage(float damage)
    {
        if (_hasShield && _shield > 0)
        {
            float remainingDamage = Mathf.Max(0, damage - _shield);
            _shield = Mathf.Max(0, _shield - damage);
            OnShieldChanged?.Invoke(_shield);
            
            if (_shield <= 0)
            {
                DeactivateShield();
            }

            damage = remainingDamage;
            if (damage <= 0) return;
        }

        _health = Mathf.Max(0, _health - damage);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        OnPlayerDeath?.Invoke();
        // Handle player death (e.g., show game over screen, respawn, etc.)
    }

    public void Heal(float amount)
    {
        if (amount <= 0) return;
        
        float previousHealth = _health;
        _health = Mathf.Clamp(_health + amount, 0f, _maxHealth);
        float actualHeal = _health - previousHealth;
        
        if (actualHeal > 0)
        {
            OnHeal?.Invoke(actualHeal);
        }
    }

    public void ActivateShield(float duration, float shieldAmount)
    {
        _hasShield = true;
        _currentShieldTime = duration;
        _shield = Mathf.Min(shieldAmount, _maxShield);
        OnShieldActivated?.Invoke();
        OnShieldChanged?.Invoke(_shield);
    }

    private void DeactivateShield()
    {
        if (!_hasShield) return;
        
        _hasShield = false;
        _shield = 0f;
        _currentShieldTime = 0f;
        OnShieldDeactivated?.Invoke();
        OnShieldChanged?.Invoke(0f);
    }

    public float GetHealth()
    {
        return _health;
    }
}
