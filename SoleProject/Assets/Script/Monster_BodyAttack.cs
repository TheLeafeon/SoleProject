using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_BodyAttack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;


    public int monster_AttackDamage = -1;
    public AudioClip hitClip;



    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();

        if (p != null)
        {
            UnityEngine.Debug.Log(" Collision with " + other.gameObject);

            p.ChangeHp(monster_AttackDamage, hitClip);

        }
    }
}
