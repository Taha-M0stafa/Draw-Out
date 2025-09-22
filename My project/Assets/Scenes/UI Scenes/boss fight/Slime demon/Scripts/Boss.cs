using UnityEngine;
using UnityEngine.Rendering;

public class Boss : MonoBehaviour
{
    private Animator anims;
    private GameObject player;
    private Rigidbody2D bossRb;
    private float velocity = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anims = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        BossMovement();
    }
    void FixedUpdate()
    {
        //BossMovement();
    }
    private void BossMovement()
    {
        gameObject.transform.position += new Vector3(player.transform.position.x + 1f, player.transform.position.y, 0) * velocity * Time.deltaTime;
    }
    
}
