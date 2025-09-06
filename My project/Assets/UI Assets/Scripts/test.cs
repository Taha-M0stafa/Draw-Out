using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject hpManager;
    public healthOrb health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = hpManager.GetComponent<healthOrb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamaged(20f);
        }
    }
    public void GetDamaged(float damage)
    {
        
        health.SetHealth(health.slider.value - damage);
    }
}
