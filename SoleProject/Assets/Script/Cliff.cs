using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    public GameObject respawnPoint;
    public AudioClip hitClip;

    int cliffDamage = -1;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }
    void Start()
    { 
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();
        Vector2 respawnPointLocation = Vector2.zero;

        if(respawnPoint != null)
        {
            respawnPointLocation = respawnPoint.transform.position;
        }

        if (p != null)
        {
            UnityEngine.Debug.Log("Player Drop ");

            p.ChangeHp(cliffDamage, hitClip);

        }
        p.transform.position = respawnPointLocation;
    }

}
