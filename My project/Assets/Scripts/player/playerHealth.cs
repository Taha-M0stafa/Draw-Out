using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float health = 5f;
     private float Maxhealth = 5f;
     Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        if (inventory == null)
        {
            Debug.LogError("Inventory component not found on the GameObject.");
        }

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
            Debug.Log("Game Over");
            Upgradesystem resetUpgrades = inventory.GetComponent<Upgradesystem>();
            Debug.Log("Game Over1");
            resetUpgrades.removeupgrades();
            Debug.Log("Game Over2");
            Inventory resetInventory = Inventory.instance;
            Debug.Log("Game Over3");
            resetInventory.ResetInventory();
            Debug.Log("Game Over4");
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
