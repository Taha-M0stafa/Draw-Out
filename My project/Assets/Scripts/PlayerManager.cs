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
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {
        GetPLayerSpawnpoint();


        Instantiate(Player, PlayerSpawnpoint.transform.position, Quaternion.identity);



    }
     void GetPLayerSpawnpoint()
    {
        PlayerSpawnpoint = GameObject.FindGameObjectWithTag("PlayerSpawnpoint");
    }
}
