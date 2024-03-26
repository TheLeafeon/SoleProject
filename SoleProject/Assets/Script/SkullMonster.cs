using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMonster : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    public float monsterSpeed = 0.0f;


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.flipX = true;
    }

}

