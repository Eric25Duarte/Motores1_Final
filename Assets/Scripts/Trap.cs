using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public abstract void TriggerEffect(Collider2D collider);

    public void ApplyDebuff(Player Player, Enemy enemy)
    {
        Debug.Log(" logic to apply debuff");  
    }
}
