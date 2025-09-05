using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] enemeyPrefabs;

    private float delay = 2f;
    private float spawnInterval = 3f;
    void Start()
    {
        InvokeRepeating("spawnRandomEnemy", delay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandomEnemy()
    {
        int randomEnemyIndex =  Random.Range(0, enemeyPrefabs.Length);
        GameObject obj = enemeyPrefabs[randomEnemyIndex];
        GameObject clone = Instantiate(obj , transform.position, transform.rotation) as GameObject;
        clone.AddComponent(typeof(meleeEnemies));
        clone.layer = LayerMask.NameToLayer("enemy");
    }
}
