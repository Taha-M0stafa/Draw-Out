using UnityEngine;

public class Holygraileffect : MonoBehaviour
{
    public ParticleSystem ps;
    private float spellDamage = 5f;

   GameObject [] meleeEnemies;
    [SerializeField] private KeyCode abilityKey = KeyCode.F;
        [SerializeField] private float cooldownTime = 25f;    
    private float cooldownTimer = 0f;

    
    
      
    
    public void UseAbility()
    {
        GetEnemy();
        PlayerManager.instance.Currhealth = PlayerManager.instance.Currhealth / 2;
        PlayerManager.instance.Currmana = PlayerManager.instance.Currmana / 2;
        foreach (GameObject enemy in meleeEnemies)
        {
            meleeEnemies healthValue = enemy.GetComponent<meleeEnemies>();
            healthValue.setHealth(healthValue.getHealth() - spellDamage);
            ps.GetComponent<particleScript>().DamagedParticleEffect(enemy.transform);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        
        if (Input.GetKeyDown(abilityKey) && cooldownTimer <= 0)
        {
            UseAbility();
            cooldownTimer = cooldownTime; 
        }
    }
    void GetEnemy()
    {
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
}
