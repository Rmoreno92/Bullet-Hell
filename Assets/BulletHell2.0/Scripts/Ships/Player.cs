using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ships
{
    private float moveH, moveV;
    public ShipSpawner shipSpawner;

    private void Awake()
    {
        shipSpawner = GameObject.Find("Spawner").GetComponent<ShipSpawner>();
    }

    private void Update()
    {

        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);

        if (Input.GetKey(KeyCode.Space) && shotTimer > shotRate)
        {
            
            base.Fire();
            shotTimer = 0;
        }
        else if (shotTimer < shotRate)
        {
            shotTimer += Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shipSpawner.SpawnEnemy3(this.transform);
        base.Death();
        ShipSpawner.currentPlayerSpawned--;
    }




}
