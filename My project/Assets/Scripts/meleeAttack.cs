using System;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float damage = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void attackMelee(float damage)
    {
        Debug.Log("hit for: " + damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           attackMelee(damage);
        }
    }
}
