using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon
{
    public Vector3 Direction;
    public Bulletplayer BulletPrefab;
    public Transform SpawnPoint;
    public Camera Camera_Player;
    //public Player Player;

    public void Shoot()
    {
        //Logic to shoot basic attack
        Bulletplayer newBullet = Instantiate(BulletPrefab, SpawnPoint.position, transform.rotation);
        //newBullet.Player = this;

        var mouseWorldPosition = Camera_Player.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        newBullet.Direction = mouseWorldPosition - SpawnPoint.position;
        print("Disparo");
    }
}
