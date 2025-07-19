using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletplayer : MonoBehaviour
{
    public Vector3 Direction;

    public float Speed = 20f;
    public float Lifetime = 1f;
    public float Bullet_player_damage = 10;

    public Player player;

    private void Start()
    {
        Destroy(gameObject, Lifetime);

    }

    void Update()
    {
        transform.position += Direction.normalized * Speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var follow = collision.gameObject.GetComponent<Enemy>();
        if (follow != null)
        {
            follow.TakeDamage(Bullet_player_damage);
            Destroy(gameObject);
        }

        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(Bullet_player_damage);
            Destroy(gameObject);
        }
    }
}
