using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Gamemanager instance;
    [SerializeField] string[] LevelNames;
   
    public GameObject Portalspawnpoint;
    public GameObject enemySpawner;
    [SerializeField] GameObject Portal;
       public int Enemycount;      
      private bool Hasnoenemy=false;
      private bool portal_spawned = false;
      GameObject port;
    void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {
        Getportalspawnpoint();
        port = null;
        portal_spawned = false;
        //GetEnemycount();
      
        enemySpawner.GetComponent<spawnEnemy>().InvokeSpawnEnemy();
        Instantiate(enemySpawner, transform.position, Quaternion.identity);
        enemySpawner.GetComponent<spawnEnemy>().InvokeSpawnEnemy();  
        Hasnoenemy = false;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Loadlevel()
    {
        int Randomlevel = Random.Range(0, LevelNames.Length);
        string Nextlevel = LevelNames[Randomlevel];
        while (Nextlevel == SceneManager.GetActiveScene().name)
        {
            Randomlevel = Random.Range(0, LevelNames.Length);
            Nextlevel = LevelNames[Randomlevel];
            Debug.Log("Same level");
        }
        SceneManager.LoadScene(Nextlevel);
        Debug.Log("Next level is " + Nextlevel);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        EnemyDied();
        GetEnemycount();
        if (Enemycount >= 4)
        {
            enemySpawner.GetComponent<spawnEnemy>().stopInvoking();
        }
    }
    public void EnemyDied()
    {
        
        if (portal_spawned == false)
        {
             port = Instantiate(Portal, Portalspawnpoint.transform.position, Quaternion.identity);
             portal_spawned = true;
        }

        if (port != null)
        {
            if (Enemycount <= 0 && !Hasnoenemy)
            {
                Hasnoenemy = true;
                port.SetActive(true);
            }
            else if(Enemycount > 0 )
            {
                Hasnoenemy = false;
                port.SetActive(false);
            }
        }
    }
    void Getportalspawnpoint()
    {
        Portalspawnpoint = GameObject.FindGameObjectWithTag("Portalspawnpoint");
    }
   
    void GetEnemycount()
    {
        Enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneloaded;
    }

    
    
}
