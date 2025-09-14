using System;
using System.Collections;
using UnityEngine;

namespace spellSystem
{
    public class spellAttacks : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public ParticleSystem ps;
        private float cooldown = 3f;
        private float spellDamage;

        public GameObject fireBall;
        
        
        private int enemyLayerMask = 1<< 3;
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void PickSpell(string spellName)
        {
            switch (spellName)
            {
                case "five point star":
                    FiveStarAttack();
                    break;
                case "Circle":
                    CircleAttack();
                    break;
                case "Rectangle":
                    break;
                case "Triangle":
                    TriangleAttack();
                    break;
            }
        }

        void FiveStarAttack()
        {
            spellDamage = 3f;
            float sphereRadius = 12f;
            Collider2D[] enemeyStats = Physics2D.OverlapCircleAll(transform.position, sphereRadius, enemyLayerMask);
            if (enemeyStats.Length > 0)
            {
                foreach (Collider2D enemy in enemeyStats)
                {
                    meleeEnemies enemyStat = enemy.gameObject.GetComponent<meleeEnemies>();
                    enemyStat.setHealth(enemyStat.getHealth() - spellDamage);
                    ps.GetComponent<particleScript>().DamagedParticleEffect(enemyStat.gameObject.transform);
                }
            }
        }

        void CircleAttack()
        {
            float sphereRadius = 8f;
           Collider2D[] enemeyStats = Physics2D.OverlapCircleAll(transform.position, sphereRadius, enemyLayerMask);
           if (enemeyStats.Length > 0)
           {
               foreach (Collider2D enemy in enemeyStats)
               {
                   meleeEnemies enemyStat = enemy.gameObject.GetComponent<meleeEnemies>();
                   StartCoroutine(freezeCoroutine(1f, enemyStat));
               }
           }
        }

        private void TriangleAttack()
        {
            var fireballClone = Instantiate(fireBall, transform.position, Quaternion.Euler(new Vector3(0, 1 ,0)));
        }
        
        private void RectangleAttack()
        {
            
        }
        
        private IEnumerator freezeCoroutine(float duration, meleeEnemies target)
        {
            float elapsedTime = 0;
            target.setCanMove(false);
            while (elapsedTime < duration)
            {
                target.getRb().linearVelocity = Vector2.zero;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            target.setCanMove(true);
        }

       
    }
}
