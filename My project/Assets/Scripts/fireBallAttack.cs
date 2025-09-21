using System;
using UnityEngine;
using UnityEngine.UI;

public class fireBallAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private const float SPEED = 3000f;
    private float damage = 3.5f;
    public GameObject explosion;

    public AudioClip impact;
    AudioSource audioSource;

    private Vector3[] Directions;
    public DIRECTION direction;

    private float deathTime = 2f;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        Directions = new Vector3[4];
        Directions[0] = new Vector3(0, -1, 0);
        Directions[1] = new Vector3(1, 0, 0);
        Directions[2] = new Vector3(0, 1, 0);
        Directions[3] = new Vector3(-1, 0, 0);
    }

    public enum DIRECTION
    {
        DOWN = 0,
        RIGHT = 1,
        UP = 2,
        LEFT = 3,
    }

    // Update is called once per frame
    void Update()
    {

        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void moveFireBall(DIRECTION dir)
    {
        try
        {
            rb.linearVelocity = Directions[(int)dir] * (SPEED * Time.deltaTime);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
            throw;
        }
    }

    public void moveFireBall(int dir)
    {
        try
        {
            rb.linearVelocity = Directions[dir] * (SPEED * Time.deltaTime);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
            throw;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dealDamageToEnemy(other.gameObject.GetComponent<meleeEnemies>());
            Destroy(this.gameObject);
        }

    }

    private void dealDamageToEnemy(meleeEnemies enemy)
    {
        enemy.setHealth(enemy.getHealth() - damage);
        PlayExplosionEffect(enemy);
    }

    private void PlayExplosionEffect(meleeEnemies enemy)
    {
        try
        {
            var explosionEffect = Instantiate(explosion, enemy.gameObject.transform) as GameObject;
            explosionEffect.transform.position += new Vector3(0, 0.5f, 0);
            explosionEffect.transform.localScale = new Vector3(2, 2, 2);
            audioSource.Play();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public void setDamage(float newDamage)
    {
        damage = newDamage;
    }
    public float getDamage()
    {
        return damage;
    }
    
}

