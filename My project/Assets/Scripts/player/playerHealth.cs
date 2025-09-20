using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float health = 5f;
     private float Maxhealth = 5f;

    void Start()
    {

    }


    void Update()
    {
        gameOver();
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    private void gameOver()
    {
        if (health <= 0)
        {
            Upgradesystem resetUpgrades = GetComponent<Upgradesystem>();
            resetUpgrades.removeupgrades();
            Inventory resetInventory = Inventory.instance;
            resetInventory.ResetInventory();
        }
    }

   



    public float GetMaxHealth()
    {
        return Maxhealth;
    }

    public void SetMaxHealth(float Maxhealth)
    {
        this.Maxhealth = Maxhealth;
    }
    



    
    
}
