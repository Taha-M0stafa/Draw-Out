using UnityEngine;
using UnityEngine.InputSystem.Android;

public class LevelTrigger : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {Debug.Log("Player entered the portal");
        Gamemanager.instance.Loadlevel();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
