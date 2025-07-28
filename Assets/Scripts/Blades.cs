using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : Weapon
{
   public void SpawnBlades()
    {
        //Logic to spawn Blades
    }

    private void OnTriggerEnter2D(Collider2D other)    
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BulletPlayer"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }
    
}
