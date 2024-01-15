using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    //1데미지를 준다.
    public int projectileDamage = -1;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();
        
        if (p != null)
        {
            UnityEngine.Debug.Log("Projectile Collision with " + other.gameObject);
            p.ChangeHp(projectileDamage);
        }
        Destroy(gameObject);
    }
}
