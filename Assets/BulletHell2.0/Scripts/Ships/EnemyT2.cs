using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT2 : Ships
{
    Vector2 newLocation;
    private Transform target;
    public float waitTimer;
    bool waitingTime;
    void Start()
    {
        newLocation = new Vector2(Random.Range(-8, 8), Random.Range(-1, 4.5f));
        waitTimer = 3.0f;
        waitingTime = false;
    }

    void Update()
    {        
        if (Vector2.Distance(transform.position, newLocation) < .1f)
        {
            newLocation = new Vector2(Random.Range(-8, 8), Random.Range(-1, 4.5f));
            waitingTime = true;
        }
        if (waitTimer >= 0 && waitingTime == true)
        {
            if (ShipSpawner.currentPlayerSpawned > 0)
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                transform.up = target.position - transform.position;
                base.Fire();
                waitTimer -= Time.deltaTime;
            }
        }
        else if(waitTimer <= 0)
        {
            waitingTime = false;
            waitTimer = 3;
        }
        if (waitingTime == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, newLocation, moveSpeed * Time.deltaTime);
        }
        if (maxLife <= 0)
        {
            base.Death();
            ShipSpawner.currentEnemy2Spawned--;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            maxLife -= 1;
        }
        if (collision.tag == "EnemyT3" || collision.tag =="EnemyT3Bullet")
        {
            base.Death();
        }

    }
}
