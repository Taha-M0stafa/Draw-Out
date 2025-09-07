using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] enemeyPrefabs;
    public GameObject spawnLocation;
    private int enemiesSpawned = 0;
    
    private float delay = 0f;
    private float spawnInterval = 3f;
    void Awake()
    {
        
    }
    
    public void InvokeSpawnEnemy()
    {
        spawnLocation =  GameObject.FindGameObjectWithTag("Enemyspawnpoint");
        InvokeRepeating("spawnRandomEnemy", delay, spawnInterval);
    }

    public void stopInvoking()
    {
        CancelInvoke();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned >= 4)
        {
            CancelInvoke();
            enemiesSpawned = 0;
        }
    }

    void spawnRandomEnemy()
    {
        int randomEnemyIndex =  Random.Range(0, enemeyPrefabs.Length);
        GameObject obj = enemeyPrefabs[randomEnemyIndex];
        GameObject clone = Instantiate(obj , spawnLocation.transform.position, spawnLocation.transform.rotation) as GameObject;
        clone.layer = LayerMask.NameToLayer("enemy");
        enemiesSpawned += 1;
    }
}
