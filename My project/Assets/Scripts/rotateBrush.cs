using UnityEngine;

public class BrushAttack : MonoBehaviour
{
    private Vector2 _virtualMousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        _virtualMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float lookDegree = Mathf.Atan2(_virtualMousePosition.y - transform.position.y , _virtualMousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion lookAtMouse = Quaternion.Euler(0,0,lookDegree);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtMouse, 0.3f);
    }
    
    
}
