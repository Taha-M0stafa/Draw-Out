using UnityEngine;
using UnityEngine.InputSystem.Android;

public class LevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Gamemanager.instance.Invoke("Loadlevel", 2f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
