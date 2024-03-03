using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float JumpForce = 7f;
    public float speed = 4.0f;
    private float moveDirection;
   
     private bool jump;
    private bool grounded = true;
    private bool moving;
   private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);


    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if (rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rigidbody2D.velocity = new Vector2(x: speed * moveDirection, rigidbody2D.velocity.y);

        if (jump == true)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, y: JumpForce);
            jump = false;
        }
    }


    private void Update()
    {
        if (grounded == true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                
                moveDirection = -1.0f;
                spriteRenderer.flipX = true;
                animator.SetFloat("speed", speed);


            }
            else if (Input.GetKey(KeyCode.D))
            {
                
                moveDirection = 1.0f;
                spriteRenderer.flipX = false;
                animator.SetFloat("speed", speed);

            }

        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            animator.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            animator.SetTrigger("jump");
            animator.SetBool("grounded", false);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
                grounded = true;
            animator.SetBool("grounded",true);
        }
      
    }

}

    
