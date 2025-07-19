using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;

    private void Update()
    {
        Move();
        HandleAttack();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * Speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Basic Attack Triggered.");
            // Trigger basic attack logic.
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Special Ability Activated.");
            // Trigger special ability logic.
        }
    }
}
