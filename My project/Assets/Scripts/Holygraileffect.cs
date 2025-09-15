using System.ComponentModel.Design;
using UnityEngine;

public class Holygraileffect : MonoBehaviour
{
    
    private float spellDamage = 5f;

   GameObject [] meleeEnemies;

[SerializeField] private float cooldownTime = 10f;

    private float cooldownTimer = 0f;

    
    
      
    
    public void UseAbility()
    {
        Inventory checkinv = Inventory.instance;
        if (!checkinv.slots.Exists(s => s.item.Itemname == "HolyGrail"))
        {
            Debug.Log("You don't have the Holygrail");
            return;
        }
        GetEnemy();
        PlayerManager.instance.Currhealth = PlayerManager.instance.Currhealth / 2;
        PlayerManager.instance.Currmana = PlayerManager.instance.Currmana / 2;
        foreach (GameObject enemy in meleeEnemies)
        {
            meleeEnemies healthValue = enemy.GetComponent<meleeEnemies>();
            healthValue.setHealth(healthValue.getHealth() - spellDamage);
            
            Debug.Log("Enemy hit for: " + spellDamage);
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

              
        if (Input.GetKeyDown(KeyCode.F)&& cooldownTimer <= 0)
        {
            UseAbility();
            cooldownTimer = cooldownTime;
            Debug.Log("Ability used, cooldown started.");
            Debug.Log("Current Health: " + PlayerManager.instance.Currhealth);
        }
    }
    void GetEnemy()
    {
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
}
