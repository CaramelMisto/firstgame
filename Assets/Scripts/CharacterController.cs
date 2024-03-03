using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator animator;
    private Vector3 charPos;
#pragma warning disable CS0108 // Üye devralýnmýþ üyeyi gizler; yeni anahtar sözcük eksik
    [SerializeField] private GameObject camera;
#pragma warning restore CS0108 // Üye devralýnmýþ üyeyi gizler; yeni anahtar sözcük eksik
    private SpriteRenderer spriteRenderer;
     void Start()
    {
        r2d = GetComponent<Rigidbody2D>();//caching r2d
        animator = GetComponent<Animator>();//caching animtor
        charPos = transform.position; 
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(x: speed, y: 0.0f);
    }

    void Update()
    {
        
        charPos = new Vector3(x: charPos.x + (Input.GetAxis("Horizontal") *speed * Time.deltaTime), charPos.y);
        
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            animator.SetFloat("speed", 0.0f);

        }
        else
        {
            animator.SetFloat("speed", 1.0f);
        }

        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            spriteRenderer.flipX = false;

        }

        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            spriteRenderer.flipX = true;

        }

        
    }


    private void LateUpdate()
    {
        camera.transform.position = new Vector3(x:charPos.x, y:charPos.y, z:charPos.z -1.0f);
    }



}
