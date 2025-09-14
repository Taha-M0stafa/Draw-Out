using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class charMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private InputAction moveAction;
    private const float SPEED = 200f;
    private const float SPRINT_FACTOR = 2f;
    
    private Rigidbody2D rb;
    private Animator m_Animator;
    
    private bool _canDash = true;
    private bool _isDashing = false;
    public float dashTime = 1f;
    public float dashPower = 15f;
    private Vector2 dashDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        m_Animator = GetComponent<Animator>();
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
            
            if (moveValue != Vector2.zero)
            {
                m_Animator.SetBool("isMoving", true);
                dashDirection = moveValue;
                
                if (isSprinting)
                {
                    m_Animator.SetBool("isRunning", true);
                    rb.linearVelocity = moveValue * (SPEED * Time.deltaTime * SPRINT_FACTOR);
                }
                else
                {
                    m_Animator.SetBool("isRunning", false);
                    rb.linearVelocity = moveValue * (Time.deltaTime * SPEED);
                }
            }
            else
            {
                m_Animator.SetBool("isMoving", false);
                rb.linearVelocity = Vector2.zero;
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
            rb.linearVelocity = moveValue * (dashPower * Time.deltaTime * (SPEED/3));
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