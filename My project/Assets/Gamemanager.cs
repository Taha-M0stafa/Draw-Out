using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Gamemanager instance;
    [SerializeField ] string [] LevelNames;






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

    void Loadlevel()
    {
        int RandomLevel = Random.Range(0, LevelNames.Length);
        string NextLevel = LevelNames[RandomLevel];
        while (NextLevel == SceneManager.GetActiveScene().name)
        {
            RandomLevel = Random.Range(0, LevelNames.Length);
            NextLevel = LevelNames[RandomLevel];



        }
        SceneManager.LoadScene(NextLevel);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
