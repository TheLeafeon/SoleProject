using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    Animator animator;

    

    //캐릭터 스테이터스
    public float playerSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        UnityEngine.Debug.Log(horizontal);

        Vector2 position = rigidbody2d.position;

        position.x = position.x + playerSpeed * horizontal * Time.deltaTime;

        rigidbody2d.MovePosition(position);

    }
}
