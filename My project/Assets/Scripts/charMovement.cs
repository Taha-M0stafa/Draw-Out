using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class charMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private InputAction moveAction;
    private const float SPEED = 200f;
    private const float SPRINT_FACTOR = 10f;

    private Rigidbody rb;
    
    
    private bool _canDash = true;
    private bool _isDashing = false;
    public float dashTime = 1f;
    public float dashPower = 15f;
    private Vector2 dashDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>().normalized;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if (!_isDashing)
        {
            if (isSprinting)
            {
                rb.linearVelocity = moveValue * (SPEED * Time.deltaTime * SPRINT_FACTOR);
            }
            else
            {
                rb.linearVelocity = moveValue * (Time.deltaTime * SPEED);
            }

            
            if (moveValue != Vector2.zero)
            {
                dashDirection = moveValue;
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && _canDash)
            {
                IEnumerator coroutine = DashCoroutine(dashDirection);
                
                StartCoroutine(coroutine);
            }
        }
    }


    private IEnumerator DashCoroutine(Vector2 moveValue)
    {
        float startTime = Time.time;
        Debug.Log("JUst outside the if condition!!!!!");
        Debug.Log("About to dash oh boy!!");
        _isDashing = true;
        while (Time.time < startTime + dashTime)
        {
            rb.linearVelocity = moveValue * (dashPower * Time.deltaTime);
            Debug.Log("Dashing!");
            yield return null;
        }

        _canDash = false;
        _isDashing = false;
        yield return RefreshDash();
    }

    private IEnumerator RefreshDash()
    {
        yield return new WaitForSeconds(0.5f);
        _canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }
}