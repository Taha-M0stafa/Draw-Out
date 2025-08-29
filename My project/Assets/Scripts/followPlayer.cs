using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private float offsetX;
    private float offsetY;
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y  , player.transform.position.z);
    }
}
