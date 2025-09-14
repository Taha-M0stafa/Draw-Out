using System;
using UnityEngine;

public class brushHitEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Brush_Attack brushPivot;
    private float damage = 2f;
    void Start()
    {
        brushPivot = GetComponentInParent<Brush_Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            brushPivot.dealDamage(other.gameObject, damage, 100f);
        }
    }
}
