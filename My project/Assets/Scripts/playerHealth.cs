using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float health = 5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
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
            Debug.Log("GameOver");
        }
    }
    
}
