using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SkullMonster : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    public float monsterSpeed = 0.0f;
    bool isMonsterActive = true;
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
        ////���� ��Ȱ��ȭ -> Ȱ��ȭ
        //if (!isMonsterActive)
        //{
        //    UnityEngine.Debug.DrawRay(rigidbody2d.position, Vector3.down * 20, new Color(0, 1, 0));

        //    //20�� �밭�� ��ġ
        //    RaycastHit2D rayHit = Physics2D.Raycast(rigidbody2d.position, Vector3.down, 20, LayerMask.GetMask("Player"));

        //    if (rayHit.collider != null)
        //    {
        //        UnityEngine.Debug.Log(rayHit.collider.name);
        //        isMonsterActive = true;
        //    }
        //}
        
        //���� Ȱ��ȭ ���¿��� �ൿ
        if(isMonsterActive)
        {
            Vector2 move = new Vector2(lookDirection.x, lookDirection.y);

            rigidbody2d.velocity = new Vector2(move.x * monsterSpeed, lookDirection.y);
        }

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

