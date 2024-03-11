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
    //효과음
    AudioSource audioSource;


    //게임오버 패널
    public GameObject gameoverPanel;


    //캐릭터 스테이터스
    public float playerSpeed = 0.0f;
    public float playerJumpPower = 0.0f;
    private bool isFly = false;
    public int playerMaxHp = 5;
    int playerNowHp;
    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invinsibleTimer=0.0f;

    Vector2 lookDirection = new Vector2(1, 0);

    //스테이지 확인용 변수
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
            //방향전환
            if (Input.GetButton("Horizontal") && !gameManager.isAction)
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            //점프
            if (Input.GetButtonDown("Jump") && !isFly && !gameManager.isAction)
            {
                isFly = true;
                rigidbody2d.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);

                UnityEngine.Debug.Log("Jump");
            }

            //대화
            if (Input.GetButtonDown("Next"))
            {
                UnityEngine.Debug.DrawRay(rigidbody2d.position, lookDirection, new Color(0, 1, 0));

                RaycastHit2D rayHit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 1, LayerMask.GetMask("Npc"));

                if (rayHit.collider != null)
                {
                    UnityEngine.Debug.Log(rayHit.collider.name);
                    gameManager.Action(rayHit.collider.gameObject);
                }
                UnityEngine.Debug.Log("Next");
            }
        }


        //무적체크
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
            float horizontal = gameManager.isAction ? 0 :  Input.GetAxis("Horizontal");


            //Vector2 position = rigidbody2d.position;

            Vector2 move = new Vector2(horizontal, rigidbody2d.velocity.y);

            if (!Mathf.Approximately(move.x, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
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


            //점프 감지
            if (rigidbody2d.velocity.y < 0.0f)
            {
                UnityEngine.Debug.DrawRay(rigidbody2d.position, Vector3.down, new Color(0, 1, 0));

                RaycastHit2D rayHit = Physics2D.Raycast(rigidbody2d.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 1.0f)
                    {
                        
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

            //체력UI 변경
            UIHpBar.instance.SetHp(playerNowHp);

            //효과음 출력
            if (audioSource != null)
            {
                PlaySound(clip);
            }
            //반짝임
            StartCoroutine(DamageEffect());

            if(playerNowHp <= 0)
            {
                gameoverPanel.SetActive(true);
            }
        }
        else
        {
            

            //효과음 출력
            if (audioSource != null)
            {
                PlaySound(clip);
            }
            playerNowHp = Mathf.Clamp(playerNowHp + amount, 0, playerMaxHp);
            UnityEngine.Debug.Log(playerNowHp + "/" + playerMaxHp);

            //체력UI 변경
            UIHpBar.instance.SetHp(playerNowHp);
        }
    }

    //피격시 깜빡임
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

    //몬스터 밟았을때 살짝 점프
    public void LaunchCharacter(float launchPower)
    {
        isFly = true;
        rigidbody2d.AddForce(Vector2.up * launchPower, ForceMode2D.Impulse);

        UnityEngine.Debug.Log("Launch");
    }

    //한번 더 점프 가능
    public void MoreJump()
    {
        isFly=false;
    }

    public bool GetisFly()
    {
        return isFly;
    }

}
