using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

namespace spellSystem
{
    public class spellAttacks : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public ParticleSystem ps;
        private float cooldown = 3f;
        private float spellDamage;

        public GameObject fireBall;

        public GameObject electricity;

        private int enemyLayerMask = 1 << 3;
        public ManaManagement mana;
        //public GameObject manaOrb;
        float fiveStarSpellCost = 10f;
        float circleSpellCost = 5f;
        float rectangleSpellCost = 5f;
        float triangleSpellCost = 5f;

        void Start()
        {
            mana = GameObject.FindWithTag("ManaOrb").GetComponent<ManaManagement>();
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
                    if (mana.GetMana() >= fiveStarSpellCost)
                    {
                        FiveStarAttack();
                        mana.UpdateMana(fiveStarSpellCost);
                    }
                    break;
                case "Circle":
                    if (mana.GetMana() >= circleSpellCost)
                    {
                        CircleAttack();
                        mana.UpdateMana(circleSpellCost);
                    }
                        break;
                case "Rectangle":
                    break;
                case "Triangle":
                    if (mana.GetMana() >= triangleSpellCost)
                    {
                        TriangleAttack();
                        mana.UpdateMana(triangleSpellCost);
                    }
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
                    var electricityClone = Instantiate(electricity, enemy.gameObject.transform);
                    electricityClone.transform.position += new Vector3(0, 0.5f, 0);
                    electricityClone.transform.localScale = new Vector3(2, 4, 1);
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
            for (int x = 0; x < 4; x++)
            {
                var fireballClone = Instantiate(fireBall, transform.position, Quaternion.Euler(new Vector3(0, 0, 90 * x)));
                fireballClone.GetComponent<fireBallAttack>().moveFireBall(x);
            }
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
