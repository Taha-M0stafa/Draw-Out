using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Gamemanager instance;
    [SerializeField] string[] LevelNames;
     [SerializeField] GameObject Player;
    public GameObject Portalspawnpoint;
    [SerializeField] GameObject Portal;
    public GameObject PlayerSpawnpoint;
    public int Enemycount;      


    void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {


        Getportalspawnpoint();
        //GetEnemycount();
        GetPLayerSpawnpoint();
        Instantiate(Player, PlayerSpawnpoint.transform.position, Quaternion.identity);
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



        }
        SceneManager.LoadScene(Nextlevel);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnemyDied()
    {
        Enemycount--;
        if (Enemycount <= 0)
        {
            Instantiate(Portal, Portalspawnpoint.transform.position, Quaternion.identity);
        }
    }
    void Getportalspawnpoint()
    {
        Portalspawnpoint = GameObject.FindGameObjectWithTag("Portalspawnpoint");
    }
    void GetPLayerSpawnpoint()
    {
        PlayerSpawnpoint = GameObject.FindGameObjectWithTag("PlayerSpawnpoint");
    }
   /* void GetEnemycount()
    {
<<<<<<< HEAD:My project/Assets/Scripts/Gamemanager.cs
        Enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }*/
=======
//        Enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
>>>>>>> main:My project/Assets/Resources/Scripts/Gamemanager.cs
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneloaded;
    }

}
