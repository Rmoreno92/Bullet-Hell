using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullets
{
    private void Start()
    {
        base.Shot();
    }
    void Update()
    {
        if (deathTimer < lifeSpan)
        {
            deathTimer += Time.deltaTime;
        }
        else if (deathTimer >= lifeSpan)
        {
            base.Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.Death();
    }
}
