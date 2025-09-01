using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class charMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CharacterController controller;
    private InputAction moveAction;
    private InputAction jumpAction;
    private const float SPEED = 10f;
    private const float SPRINT_FACTOR = 2f;

    private bool _canDash = true;
    private bool _isDashing = false;
    public float dashTime = 1f;
    public float dashPower = 15f;
    private Vector2 dashDirection;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (!_isDashing)
        {
            if (isSprinting)
            {
                controller.Move(moveValue * (SPEED * Time.deltaTime * SPRINT_FACTOR));
            }
            else
            {
                controller.Move(moveValue * (Time.deltaTime * SPEED));
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
            controller.Move(moveValue * (dashPower * Time.deltaTime));
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