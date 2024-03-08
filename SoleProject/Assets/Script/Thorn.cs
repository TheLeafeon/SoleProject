using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public AudioClip hitClip;

    int ThornDamage = -1;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();

        if (p != null)
        {
            UnityEngine.Debug.Log("Player Drop ");

            p.ChangeHp(ThornDamage, hitClip);

            p.LaunchCharacter(10.0f);

        }
    }
}
