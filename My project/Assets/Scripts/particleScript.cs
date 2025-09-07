using UnityEngine;
[ExecuteInEditMode]
public class particleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem ps;
  
    void Start()
    {
    }

    // Update is called once per frame
   
    void Update()
    {
        var main = ps.main;
        main.startSize = 0.2f;
    }
    
    public void DamagedParticleEffect(Transform parent)
    {
        Instantiate(ps , parent.position, parent.rotation, parent);
    }
    
}
