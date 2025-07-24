using UnityEngine;

public class BladeEnemy : Enemy
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float collisionDamage = 10f;
    [SerializeField] private GameObject bladesPrefab;
    

    private void Start()
    {
	  GameObject localBladesPrefab =Instantiate(bladesPrefab, transform.position, Quaternion.identity);
	localBladesPrefab.GetComponent<BladeGenerator>().setParent(this.gameObject);
    }
    protected override void Move()
    {
        UpdateTarget();
    
    }

    private void Update()
    {
        //base.UpdatePosition();
        Move();
        base.UpdatePosition();
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
