using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMonster : MonoBehaviour
{
    //이동용
    Rigidbody2D rigidbody2d;
    //filp용
    SpriteRenderer spriteRenderer;

    //트랜스폼
    public Transform m_tr;

    //필요한것
    /*
     * 바라보는 방향
     * 시작위치
     * 도착위치
     */

    //이동거리
    public float patrolRange = 0.0f;
    //이동속도
    public float monsterSpeed = 0.0f;


    //시작 위치
    Vector2 startLocation = new Vector2(1.0f, 0.0f);
    //도착 위치
    Vector2 patrolLocation = new Vector2(1.0f, 0.0f);
    //바라보는 방향 monsterLockDirection: -1or 1
    public float monsterLockDirection = 0.0f;

    Vector2 lookDirection = new Vector2(1, 0);

    bool isArrive = false;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        lookDirection.x = monsterLockDirection;
    }

    // Start is called before the first frame update
    void Start()
    {
        startLocation = m_tr.position;

        patrolLocation = m_tr.position;

        patrolLocation.x = patrolLocation.x + (patrolRange * monsterLockDirection);

        //처음에 방향 전환
        if(lookDirection.x < 0.0f)
        {
            spriteRenderer.flipX = lookDirection.x == 1.0f;
        }

        UnityEngine.Debug.Log(startLocation.x);
        UnityEngine.Debug.Log(patrolLocation.x);


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(lookDirection.x, rigidbody2d.velocity.y);
        rigidbody2d.velocity = new Vector2(move.x * monsterSpeed, rigidbody2d.velocity.y);

        //if(m_tr.position.x == patrolLocation.x && !isArrive)
        //{
        //    Turn();
        //}
        //if (m_tr.position.x == startLocation.x && isArrive)
        //{
        //    Turn();
        //}

        if (isArrive)
        {
            //시작지점 도착했을때
            if(Mathf.FloorToInt(m_tr.position.x) == startLocation.x)
            {
                isArrive = false;
                UnityEngine.Debug.Log("시작지점 도착");
                Turn();
            }
        }
        else
        {
            //순찰지점 도착했을때
            if (Mathf.FloorToInt(m_tr.position.x) == patrolLocation.x)
            {
                isArrive = true;
                UnityEngine.Debug.Log("순찰지점 도착");
                Turn();
            }
        }
    }

    //회전
    void Turn()
    {
        lookDirection.x *= -1;
        spriteRenderer.flipX = lookDirection.x == 1.0f;
    }
}
