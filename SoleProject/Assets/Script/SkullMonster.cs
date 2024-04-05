using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SkullMonster : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    //플레이어 위치 확인
    public GameObject playerCharacter;

    public float monsterSpeed = 0.0f;
    Vector2 lookDirection = new Vector2 (1, 0);
    public int monster_AttackDamage = -1;
    public AudioClip hitClip;

    public bool monsterLookRight = true;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if(!monsterLookRight)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Update()
    {
        if (transform.position.x > playerCharacter.transform.position.x)
        {
            spriteRenderer.flipX = true;
            lookDirection.x = -1.0f;
        }
        else if (transform.position.x < playerCharacter.transform.position.x )
        {
            spriteRenderer.flipX = false;
            lookDirection.x = 1.0f;
        }

 
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(lookDirection.x, lookDirection.y);

        rigidbody2d.velocity = new Vector2(move.x * monsterSpeed, lookDirection.y);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();

        if (p != null)
        {
            UnityEngine.Debug.Log(" OnCollisionEnter2D With" + other.gameObject);

            p.ChangeHp(monster_AttackDamage, hitClip);
        }

    }
}

