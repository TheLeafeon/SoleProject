using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string sceneName;

    Rigidbody2D rigidbody2d;


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController p = other.collider.GetComponent<PlayerController>();

        if (p != null)
        {
            if(sceneName != null)
            {
                SceneManager.LoadScene(sceneName);
            }
            
        }
    }
}
