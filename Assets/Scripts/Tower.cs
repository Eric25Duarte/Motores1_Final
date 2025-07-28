using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField]private float _currentHealth;

    [Header("UI")]
    [SerializeField] private Image healthBarImage;

    // Damage received when colliding with EnemyDmg layer
    [SerializeField] private float collisionDamage = 10f;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
        UpdateHealthBar();

        if (_currentHealth <= 0)
        {
            GameEventManager.TriggerGameOver();
        }
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
        UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = _currentHealth / _maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyDmg"))
        {
            TakeDamage(collisionDamage);
        }
    }

    // Existing health management logic...
}
