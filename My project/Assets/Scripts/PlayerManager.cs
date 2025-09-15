using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{

       static public PlayerManager instance;
    public GameObject PlayerSpawnpoint;
    public int Currhealth = 100;
    public int Maxhealth = 100;
    public int Currmana = 100;
    public int MaxMana = 100;
     

    [SerializeField] GameObject Player;
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
            Debug.Log("PlayerManager already exists, destroying duplicate!");
        }
    }


    void Start()
    {
        SceneManager.sceneLoaded += OnSceneloaded;
        GetPLayerSpawnpoint();
        
         Instantiate(Player, PlayerSpawnpoint.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
     public void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {
        GetPLayerSpawnpoint();


        Instantiate(Player, PlayerSpawnpoint.transform.position, Quaternion.identity);



    }
    void GetPLayerSpawnpoint()
    {
        PlayerSpawnpoint = GameObject.FindGameObjectWithTag("PlayerSpawnpoint");
        if (PlayerSpawnpoint == null)
        {
            Debug.LogError("No PlayerSpawnpoint found in the scene. Please add one with the 'PlayerSpawnpoint' tag.");
        }
    }
}
