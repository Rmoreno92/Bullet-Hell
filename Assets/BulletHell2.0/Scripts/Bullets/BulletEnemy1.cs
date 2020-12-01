using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy1 : Bullets
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * -shotForce);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        base.Death();
    }
}
