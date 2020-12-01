using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT3 : Ships
{
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.Fire();
    }
}
