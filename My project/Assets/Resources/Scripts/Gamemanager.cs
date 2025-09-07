using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Gamemanager instance;
    [SerializeField] string[] LevelNames;

    public GameObject Portalspawnpoint;
    [SerializeField] GameObject Portal;
    public int Enemycount; 


    void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {


        Getportalspawnpoint();
        GetEnemycount();
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
    void GetEnemycount()
    {
//        Enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
