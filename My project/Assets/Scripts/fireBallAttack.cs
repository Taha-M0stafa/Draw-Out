using System;
using UnityEngine;

public class fireBallAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private const float SPEED = 300f;
    private float damage = 3.5f;
    public GameObject explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.forward * (SPEED * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            dealDamageToEnemy(other.gameObject.GetComponent<meleeEnemies>());
            Debug.Log("hit");
        }
        Debug.Log(" hit not the enemy ");
    }


    
    private void dealDamageToEnemy(meleeEnemies enemy)
    {
        enemy.setHealth(enemy.getHealth() - damage);
        PlayExplosionEffect(enemy);
    }

    private void PlayExplosionEffect(meleeEnemies enemy)
    {
        Debug.Log("Uhh exploded");
        Instantiate(explosion, enemy.gameObject.transform);
    }
    
}

