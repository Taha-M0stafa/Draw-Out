using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    private bool isAttacking = false;
    
    private STATE state = STATE.IDLE;
    private Animator m_Animator;
    private CharacterController m_CharacterController;
    
    private Vector3 moveDirection = Vector3.zero;
    private bool isMoving = true;
    private const float SPEED = 6f;
    
    private GameObject player;
    private int layer = 3;
    private int layerMask;

    
    
    void Start()
    {
        layerMask = 1 << layer;
        m_Animator = GetComponent<Animator>();
        m_CharacterController = gameObject.AddComponent(typeof (CharacterController)) as CharacterController;
        m_CharacterController.skinWidth = 0.01f;
        m_CharacterController.excludeLayers = layerMask;
        
        player =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movementFunction();
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
                m_Animator.SetBool("isAttacking", isAttacking);
                break;
            default:
                break;
        }
    }
    
    
    void movementFunction()
    {
        rotateLeftAndRight();

        if (Vector3.Distance(transform.position, player.transform.position) > 0.2f)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            moveDirection = direction * (SPEED * Time.deltaTime);
            
            changeStates(STATE.MOVING);
            m_CharacterController.Move(moveDirection);
        }
        else
        {
            changeStates(STATE.ATTACKING);
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
    
}
