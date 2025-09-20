using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using spellSystem;


public class Upgradesystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Upgradedatabase upgradedatabase;
    Inventory inventory;
      playerHealth playerHealth;
    spellAttacks spellAttacks;
    fireBallAttack fireBallAttack;
    Holygraileffect holyGrailEffect;
    meleeAttack meleeAttack;
    void Awake()
    {
        upgradedatabase = Resources.Load<Upgradedatabase>("Upgradedatabase");
        inventory = Inventory.instance;
        if (upgradedatabase == null)
        {
            Debug.LogError("Upgradedatabase not found in Resources folder.");
        }
        if (inventory == null)
        {
            Debug.LogError("Inventory component not found on the GameObject.");
        }
        playerHealth = GetComponent<playerHealth>();
        spellAttacks = GetComponent<spellAttacks>();
        fireBallAttack = GetComponent<fireBallAttack>();
        holyGrailEffect = GetComponent<Holygraileffect>();
        meleeAttack = GetComponent<meleeAttack>();

        
    }
    public UpgradeSO GetRandomUpgrade()
    {
        if (upgradedatabase != null && upgradedatabase.Upgrade != null && upgradedatabase.Upgrade.Length > 0)
        {
            int randomIndex = Random.Range(0, upgradedatabase.Upgrade.Length);
            return upgradedatabase.Upgrade[randomIndex];
        }
        else
        {
            Debug.LogWarning("Upgradedatabase is empty or not initialized.");
            return null;
        }
    }
  

    
    public void ApplyUpgrade(UpgradeSO upgrade)
    {

        if (upgrade != null)
        {
            switch (upgrade.UpgradeTypes)
            {
                case "spellldamageboost":
                    
                    spellAttacks.SetFivestarattackDamage(spellAttacks.getSpellDamage() + upgrade.Upgradeamount);
                    inventory.Addupgrade(upgrade);
                    Debug.Log("Applying weapon upgrade: " + upgrade.Upgradename);
                    break;
                case "Healthstatboost":
                    playerHealth = GetComponent<playerHealth>();
                    playerHealth.SetMaxHealth(playerHealth.GetMaxHealth() + upgrade.Upgradeamount);
                    inventory.Addupgrade(upgrade);
                    Debug.Log("Applying stat upgrade: " + upgrade.Upgradename);
                    break;
                case "holyhealthupgrade":

                    if (!inventory.slots.Exists(s => s.item.Itemname == "HolyGrail"))
                    {
                        Debug.Log("You don't have the Holygrail");
                        return;
                    }
                    
                    holyGrailEffect.SetHealthCost(holyGrailEffect.GetHealthCost() * .5f);
                    inventory.Addupgrade(upgrade);
                    Debug.Log("Applying special upgrade: " + upgrade.Upgradename);
                    break;
                case "holydamageupgrade":
                    if (!inventory.slots.Exists(s => s.item.Itemname == "HolyGrail"))
                    {
                        Debug.Log("You don't have the Holygrail");
                        return;
                    }

                   
                    holyGrailEffect.SetSpellDamage(holyGrailEffect.GetSpellDamage() + upgrade.Upgradeamount);
                    inventory.Addupgrade(upgrade);
                    Debug.Log("Applying special upgrade: " + upgrade.Upgradename);
                    break;
                case "weaponstatboost":
                   
                    meleeAttack.SetMeleeDamage(meleeAttack.GetMeleeDamage() + upgrade.Upgradeamount);
                    inventory.Addupgrade(upgrade);

                    Debug.Log("Applying special upgrade: " + upgrade.Upgradename);
                    break;
                case "traingeldamageboost":
                   
                    fireBallAttack.setDamage(fireBallAttack.getDamage() + upgrade.Upgradeamount);
                    inventory.Addupgrade(upgrade);

                    Debug.Log("Applying special upgrade: " + upgrade.Upgradename);
                    break;
                default:
                    Debug.LogWarning("Unknown upgrade type: " + upgrade.UpgradeTypes);
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Upgrade is null, cannot apply.");
        }
    }
    public void removeupgrades()
    {
        
            Debug.Log("Clearing upgrades from inventory");
            playerHealth = GetComponent<playerHealth>();
        
            playerHealth.SetMaxHealth(5);
            spellAttacks = GetComponent<spellAttacks>();
            spellAttacks.SetFivestarattackDamage(3);
            holyGrailEffect = GetComponent<Holygraileffect>();
            holyGrailEffect.SetHealthCost(0.5f);
            holyGrailEffect.SetSpellDamage(5);
            meleeAttack = GetComponent<meleeAttack>();
            meleeAttack.SetMeleeDamage(1);
            fireBallAttack = GetComponent<fireBallAttack>();
            fireBallAttack.setDamage(3.5f);
            Debug.Log("Upgrades removed");
       
    }
}
