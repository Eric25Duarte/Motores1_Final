using UnityEngine;

public class ShooterEnemy : Enemy
{
    protected override void Move()
    {
        // Logic for staying at a distance and shooting.
        Debug.Log("ShooterEnemy is moving.");
    }
}
