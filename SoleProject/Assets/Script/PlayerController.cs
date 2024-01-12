using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;
    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);

    //캐릭터 스테이터스
    public float playerSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //방향전환
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }

    void FixedUpdate()
    {
        //float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
       

        Vector2 position = rigidbody2d.position;

        Vector2 move = new Vector2(horizontal, rigidbody2d.velocity.y);

        if (!Mathf.Approximately(move.x, 0.0f))
        {
            lookDirection.x = move.x;
            
            lookDirection.Normalize();
        }
        if(Mathf.Abs(move.x)>0.3f)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        position = position + move * playerSpeed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
