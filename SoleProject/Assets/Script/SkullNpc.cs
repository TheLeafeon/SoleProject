using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullNpc : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;


    //플레이어 위치 확인
    public GameObject playerCharacter;

    //스컬 몬스터
    public GameObject skullMonster;

    public GameManager gameManager;
    //대화가 끝나는 타이밍
    public int skullNpcTalkEnd = 5;
    bool isTransform = false;

    public bool transformEnd= false;

    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(playerCharacter == null )
        {
            UnityEngine.Debug.Log("플레이어를 찾을 수 없음");
        }
        

    }


    void Update()
    {
        if(!isTransform && skullNpcTalkEnd == gameManager.talkIndex)
        {
            isTransform = true ;
            UnityEngine.Debug.Log("변신");

            animator.SetBool("isTransform", true);
        }

        if(transform.position.x > playerCharacter.transform.position.x && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }
        else if(transform.position.x < playerCharacter.transform.position.x && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }


        if(transformEnd)
        {
            UnityEngine.Debug.Log("변신 완료");
            skullMonster.SetActive(true);
            Destroy(gameObject);
        }


    }


    
}
