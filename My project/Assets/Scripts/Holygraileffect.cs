using System.ComponentModel.Design;
using UnityEngine;

public class Holygraileffect : MonoBehaviour
{

    private float spellDamage = 5f;

    GameObject[] meleeEnemies;

    [SerializeField] private float cooldownTime = 10f;

    private float cooldownTimer = 0f;

    private GameObject player;
    private playerHealth playerHealth;
    private float healthCost = 0.5f; // 50% health cost



    public void UseAbility()
    {
        Inventory checkinv = Inventory.instance;
        if (!checkinv.slots.Exists(s => s.item.Itemname == "HolyGrail"))
        {
            Debug.Log("You don't have the Holygrail");
            return;
        }
        GetEnemy();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        playerHealth.setHealth(playerHealth.getHealth() * (1 - healthCost));
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


        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer <= 0)
        {
            UseAbility();
            cooldownTimer = cooldownTime;
            Debug.Log("Ability used, cooldown started.");
            Debug.Log("Current Health: " + playerHealth.getHealth());
        }
    }
    void GetEnemy()
    {
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public void SetHealthCost(float newHealthCost)
    {
        healthCost = newHealthCost;
    }
    public void SetSpellDamage(float newSpellDamage)
    {
        spellDamage = newSpellDamage;

    }
    public float GetSpellDamage()
    {
        return spellDamage;
    }
    public float GetHealthCost()
    {
        return healthCost;
    }

}
