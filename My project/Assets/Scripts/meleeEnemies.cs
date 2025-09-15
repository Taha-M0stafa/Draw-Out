using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class meleeEnemies : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private enum STATE
    {
        IDLE = 0,
        MOVING = 1,
        ATTACKING =2,
    }

    private float health = 10f;
    private float damage = 1f;
    private bool canMove = true;
    
    private STATE state = STATE.IDLE;
    private Animator m_Animator;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    
    
    private Vector3 moveDirection = Vector3.zero;
    private bool isMoving = true;
    private const float SPEED = 150f;
    
    private GameObject player;
    private playerHealth  playerHealth;
    public ParticleSystem damagedParticleEffect;
    
    private int layer = 3;
    private int layerMask;
    
    void Start()
    {
        layerMask = 1 << layer;
        m_Animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        rb.excludeLayers = layerMask;
        
        player =  GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        movementFunction();

        if (health <= 0)
        {
            Die();
        }
    }

    void changeStates(STATE newState)
    {
        state = newState;
        setAnimationState(newState);
    }

    void setAnimationState(STATE newState)
    {
        isMoving = false;
        isAttacking = false;
        
        switch (newState)
        {
            case STATE.MOVING:
                isMoving = true;
                m_Animator.SetBool("isMoving", isMoving);
                break;
            case STATE.ATTACKING:
                isAttacking = true;
                m_Animator.SetTrigger("attack");
                break;
            default:
                break;
        }
    }
    
    
    void movementFunction()
    {
        rotateLeftAndRight();

        if (Vector3.Distance(transform.position, player.transform.position) > 0.5f && canMove)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            moveDirection = direction * (SPEED * Time.deltaTime);
            
            changeStates(STATE.MOVING);
            rb.linearVelocity = moveDirection;
        }
        
    }

    void rotateLeftAndRight()
    {
        Quaternion newRotation = transform.rotation;
        if (transform.position.x > player.transform.position.x)
        {
            newRotation.y = 0;
        }
        else if (transform.position.x <= player.transform.position.x)
        {
           newRotation.y = 180;
        }

        transform.rotation = newRotation;
    }

    void attackFunction()
    {
        changeStates(STATE.ATTACKING);
        playerHealth.setHealth(playerHealth.getHealth() - damage);
        damagedParticleEffect.GetComponent<particleScript>().DamagedParticleEffect(player.transform);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitBox"))
        {
            attackFunction();
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    public bool getCanMove()
    {
        return canMove;
    }

    public Rigidbody2D getRb()
    {
        return rb;
    }
    
}
