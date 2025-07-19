using UnityEngine;

public class SlowTrap : Trap
{
    public float SlowFactor = 0.5f;
    public float Duration = 3f;

    public override void TriggerEffect(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            //enemy.SetSpeed(enemy.BaseSpeed * SlowFactor);
            //Invoke(nameof(ResetSpeed), duration, enemy);
        }
    }

    private void ResetSpeed(Enemy enemy)
    {
        if (enemy != null)
        {
            //enemy.SetSpeed(enemy.BaseSpeed);
        }
    }
    protected override void NotifyTriggered(Collider2D collider)
    {
        RaiseTrapTriggered(collider);
    }
	protected void Debuff(Collider2D collider)
    {
        RaiseTrapTriggered(collider);
    }
}
