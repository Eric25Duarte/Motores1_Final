using UnityEngine;

public class Tower : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);

        if (_currentHealth <= 0)
        {
            GameEventManager.TriggerGameOver();
        }
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
    }

    public float GetHealthPercentage()
    {
        return _currentHealth / _maxHealth;
    }

    public static Tower Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Existing health management logic...
}
