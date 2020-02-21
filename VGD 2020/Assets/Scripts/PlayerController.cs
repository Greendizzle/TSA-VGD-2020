using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public GameObject AI;
    AI script;


    public float speed;
    public float jumpForce;  
    bool isGrounded = false;
    public Transform isGroundedChecker;
    float checkGroundRadius;
    public LayerMask groundLayer;
    float rememberGroundedFor;
    float lastTimeGrounded;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;
    Vector2 move;
    bool Jumping;


    float State = 2;
   
    
    
    bool IsAttacking;

    public int CurrentHealth;
    public int MaxHealth;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        additionalJumps = defaultAdditionalJumps;
        script = AI.GetComponent<AI>();
        CurrentHealth = MaxHealth;
        
    }

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
        StateRun();

     
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Player1Move");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    public void Jump()
    {
        if  (Input.GetButton("Player1Jump") && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }

    }

    void StateRun()
    {

        anim.SetBool("Attacking", IsAttacking);
        anim.SetFloat("State", State);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }


        if (Input.GetButtonDown("Player1StateUp") && State == 2)
        {
            State = 3;
            
            Debug.Log(State);
        }
        else if
       (Input.GetButtonDown("Player1StateUp") && State == 1)
        {
            State = 2;
           
            Debug.Log(State);
        }
        else if (Input.GetButtonDown("Player1StateDown") && State == 3)
        {
            State = 2;
            
            Debug.Log(State);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D targetObj)
    {

        if (targetObj.gameObject.tag == "Enemy")
        {
            script.health -= 1;
        }

    }

    public void TakeDamagePlayer(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);

        }
    }


}
