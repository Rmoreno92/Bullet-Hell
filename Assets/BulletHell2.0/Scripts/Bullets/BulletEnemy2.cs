    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy2 : Bullets
{
    private Transform target;

    void Update()
    {
        if (ShipSpawner.currentPlayerSpawned > 0)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.up = target.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.position, shotForce * Time.deltaTime);
        }
        if (ShipSpawner.currentPlayerSpawned <= 0)
        {
            base.Death();
        }
        deathTimer += Time.deltaTime;            
        if (deathTimer >= lifeSpan)
        {
            base.Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.Death();       
    }
}
