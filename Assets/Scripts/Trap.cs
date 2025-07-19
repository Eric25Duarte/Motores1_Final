using UnityEngine;
using System.Collections;
using System;

public abstract class Trap : MonoBehaviour
{
    public abstract void TriggerEffect(Collider2D collider);
    public event Action<Trap, Collider2D> OnTrapTriggered;

    protected void RaiseTrapTriggered(Collider2D collider)
    {
        OnTrapTriggered?.Invoke(this, collider);
    }

    public void ApplyDebuff(Player Player, Enemy enemy)
    {
        Debug.Log(" logic to apply debuff");  
    }
    protected abstract void NotifyTriggered(Collider2D collider);
} 