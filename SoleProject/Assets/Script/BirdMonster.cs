using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMonster : MonoBehaviour
{
    //�̵���
    Rigidbody2D rigidbody2d;
    //filp��
    SpriteRenderer spriteRenderer;

    //Ʈ������
    public Transform m_tr;

    //�ʿ��Ѱ�
    /*
     * �ٶ󺸴� ����
     * ������ġ
     * ������ġ
     */

    //�̵��Ÿ�
    public float patrolRange = 0.0f;
    //�̵��ӵ�
    public float monsterSpeed = 0.0f;


    //���� ��ġ
    Vector2 startLocation = new Vector2(1.0f, 0.0f);
    //���� ��ġ
    Vector2 patrolLocation = new Vector2(1.0f, 0.0f);
    //�ٶ󺸴� ���� monsterLockDirection: -1or 1
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

        //ó���� ���� ��ȯ
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
            //�������� ����������
            if(Mathf.FloorToInt(m_tr.position.x) == startLocation.x)
            {
                isArrive = false;
                UnityEngine.Debug.Log("�������� ����");
                Turn();
            }
        }
        else
        {
            //�������� ����������
            if (Mathf.FloorToInt(m_tr.position.x) == patrolLocation.x)
            {
                isArrive = true;
                UnityEngine.Debug.Log("�������� ����");
                Turn();
            }
        }
    }

    //ȸ��
    void Turn()
    {
        lookDirection.x *= -1;
        spriteRenderer.flipX = lookDirection.x == 1.0f;
    }
}
