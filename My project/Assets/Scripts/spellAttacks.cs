using UnityEngine;

public class spellAttacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject[] enemies;
    public ParticleSystem ps;
    private float spellDamage;
    
    
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
        }
    }
    
    void FiveStarAttack()
    {
        updateEnemeyCount();
        spellDamage = 2f;
        foreach (GameObject enemy in enemies)
        {
            meleeEnemies healthValue = enemy.GetComponent<meleeEnemies>();
            healthValue.setHealth(healthValue.getHealth()-spellDamage);
            ps.GetComponent<particleScript>().DamagedParticleEffect(enemy.transform);
        }
    }

    void CircleAttack()
    {
        updateEnemeyCount();
        float pushBackValue = 1.3f;
        foreach (GameObject enemy in enemies )
        {
            if(enemy.transform.position.x > transform.position.x)
            {
                enemy.transform.Translate(enemy.transform.position.x + pushBackValue, 0, 0);    
            }
            else
            {
                enemy.transform.Translate(enemy.transform.position.x-pushBackValue, 0, 0);
            }
        }
    }

    private void updateEnemeyCount()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
