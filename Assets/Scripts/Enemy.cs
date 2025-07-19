using System;
using UnityEngine;

public enum EnemyType { Blade, Shooter, Explosive }

public abstract class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private float baseSpeed = 2f; // Encapsulated field
    [SerializeField] private float health = 50f;  // Encapsulated field
    [SerializeField] private EnemyType enemyType = EnemyType.Blade;

    protected float CurrentSpeed { get; private set; }
    public float Health => health; // Expose health with read-only access
    public EnemyType Type => enemyType;

    protected Vector3 TargetPosition; // Position the enemy is moving towards
    private Coordinates _coordinates;

    public event Action<float> OnTakeDamage;
    public static event Action<Enemy> OnEnemyDeath;

    protected virtual void Start()
    {
        _coordinates = new Coordinates(transform.position);
        CurrentSpeed = baseSpeed;
        UpdateTarget();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnTakeDamage?.Invoke(damage);
        if (health <= 0)
        {
            Die();
        }
    }

    public void SetSpeed(float speed)
    {
        CurrentSpeed = speed;
    }

    public void UpdateTarget()
    {
        if (Player.Instance != null)
        {
            TargetPosition = Player.Instance.transform.position;
        }
        else if (Tower.Instance != null)
        {
            TargetPosition = Tower.Instance.transform.position;
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has been destroyed.");
        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract void Move();

    protected void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, CurrentSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
        UpdatePosition();
    }

    // IHealth implementation
    public float CurrentHealth => health;
    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0f, 100f);
    }
}
