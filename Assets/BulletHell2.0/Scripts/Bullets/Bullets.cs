using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    protected private Rigidbody2D rb;
    [SerializeField] protected private float shotForce;
    [SerializeField] protected private float lifeSpan;
    protected private float deathTimer;

    protected virtual void Shot()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * shotForce);
    }
    
    protected virtual void Death()
    {
        GameObject.Destroy(gameObject);
    }
}
