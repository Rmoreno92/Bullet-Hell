using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{    
    protected private int currentlife;
    protected private Rigidbody2D rb;
    [SerializeField] protected private int maxLife;
    [SerializeField] protected private int maxNumber;
    [SerializeField] protected private float moveSpeed;
    [SerializeField] protected private float shotRate;
    protected private float shotTimer;
    [SerializeField] protected private float respawnTimer;
    [SerializeField] protected private GameObject bulletPrefab;

    private void Start()
    {
        currentlife = maxLife;
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Fire()
    {
        
        if (shotTimer >= shotRate)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shotTimer = 0;
        }
        else if (shotTimer < shotRate)
        {
            shotTimer += Time.deltaTime;
        }
        
    }
    protected virtual void TakeDamage()
    {

    }  
    protected virtual void Death()
    {
        GameObject.Destroy(gameObject);
    }
}
