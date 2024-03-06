using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;



    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;
    Animator animator;
    //ȿ����
    AudioSource audioSource;


    //���ӿ��� �г�
    public GameObject gameoverPanel;


    //ĳ���� �������ͽ�
    public float playerSpeed = 0.0f;
    public float playerJumpPower = 0.0f;
    private bool isFly = false;
    public int playerMaxHp = 5;
    int playerNowHp;
    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invinsibleTimer=0.0f;

    //�������� Ȯ�ο� ����
    public int StageData;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerNowHp = playerMaxHp;
        isInvincible = false;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerNowHp > 0)
        {
            
            //������ȯ
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            //����
            if (Input.GetButtonDown("Jump") && !isFly)
            {
                isFly = true;
                rigidbody2d.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);

                UnityEngine.Debug.Log("Jump");
            }

            //��ȭ
            if (Input.GetButtonDown("Next"))
            {
                gameManager.Action(StageData);
                UnityEngine.Debug.Log("Next");
            }
        }


        //����üũ
        if(isInvincible)
        {
            invinsibleTimer -= Time.deltaTime;

            if(invinsibleTimer < 0)
            {
                isInvincible = false;
            }
        }

    }

    void FixedUpdate()
    {

        if (playerNowHp > 0)
        {
            //float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");


            //Vector2 position = rigidbody2d.position;

            Vector2 move = new Vector2(horizontal, rigidbody2d.velocity.y);

            if (!Mathf.Approximately(move.x, 0.0f))
            {
                //lookDirection.x = move.x;

                //lookDirection.Normalize();
            }
            if (Mathf.Abs(move.x) > 0.3f)
            {
                animator.SetBool("isWalk", true);
            }
            else
            {
                animator.SetBool("isWalk", false);
            }

            rigidbody2d.velocity = new Vector2(move.x * playerSpeed, rigidbody2d.velocity.y);


            //���� ����
            if (rigidbody2d.velocity.y < 0.0f)
            {
                UnityEngine.Debug.DrawRay(rigidbody2d.position, Vector3.down, new Color(0, 1, 0));

                RaycastHit2D rayHit = Physics2D.Raycast(rigidbody2d.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 1.0f)
                    {
                        UnityEngine.Debug.Log(rayHit.collider.name);
                        isFly = false;
                    }
                }
            }
        }
            
        
    }


    public void ChangeHp(int amount, AudioClip clip)
    {

        if (amount < 0)
        {
            if(isInvincible)
            {
                return;
            }

            playerNowHp = Mathf.Clamp(playerNowHp + amount, 0, playerMaxHp);
            UnityEngine.Debug.Log(playerNowHp + "/" + playerMaxHp);
            isInvincible = true;
            invinsibleTimer = timeInvincible;

            //ü��UI ����
            UIHpBar.instance.SetHp(playerNowHp);

            //ȿ���� ���
            if (audioSource != null)
            {
                PlaySound(clip);
            }
            //��¦��
            StartCoroutine(DamageEffect());

            if(playerNowHp <= 0)
            {
                gameoverPanel.SetActive(true);
            }
        }
        else
        {
            

            //ȿ���� ���
            if (audioSource != null)
            {
                PlaySound(clip);
            }
            playerNowHp = Mathf.Clamp(playerNowHp + amount, 0, playerMaxHp);
            UnityEngine.Debug.Log(playerNowHp + "/" + playerMaxHp);

            //ü��UI ����
            UIHpBar.instance.SetHp(playerNowHp);
        }
    }

    //�ǰݽ� ������
    IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.2f);

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    //���� ������� ��¦ ����
    public void LaunchCharacter(float launchPower)
    {
        isFly = true;
        rigidbody2d.AddForce(Vector2.up * launchPower, ForceMode2D.Impulse);

        UnityEngine.Debug.Log("Launch");
    }
}
