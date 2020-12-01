using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1 : Ships
{
    Transform waypoint1, waypoint2, waypoint3, waypoint4;
    private Transform wayPointTarget;

    private void Start()
    {
        waypoint1 = GameObject.Find("waypoint1").transform;
        waypoint2 = GameObject.Find("waypoint2").transform;
        waypoint3 = GameObject.Find("waypoint3").transform;
        waypoint4 = GameObject.Find("waypoint4").transform;
        wayPointTarget = waypoint1;
    }
    private void Update()
    {
        shotRate -= Time.deltaTime;
        if (Vector2.Distance(transform.position,waypoint1.position) < 0.01f)
        {
            wayPointTarget = waypoint2;
        }
        else if(Vector2.Distance(transform.position, waypoint2.position) < 0.01f)
        {
            wayPointTarget = waypoint3;
        }
        else if (Vector2.Distance(transform.position, waypoint3.position) < 0.01f)
        {
            wayPointTarget = waypoint4;
        }
        else if (Vector2.Distance(transform.position, waypoint4.position) < 0.01f)
        {
            wayPointTarget = waypoint1;
        }
        if (shotRate <= 0)
        {            
            base.Fire();
            shotRate = 3;
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        if (maxLife <=0)
        {
            base.Death();
            ShipSpawner.currentEnemy1Spawned--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            maxLife-= 1;
        }
        if (collision.tag == "EnemyT3")
        {
            base.Death();
        }
    }

}
