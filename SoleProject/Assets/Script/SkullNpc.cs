using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullNpc : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;


    //�÷��̾� ��ġ Ȯ��
    public GameObject playerCharacter;

    //���� ����
    public GameObject skullMonster;

    public GameManager gameManager;
    //��ȭ�� ������ Ÿ�̹�
    public int skullNpcTalkEnd = 5;
    bool isTransform = false;

    public bool transformEnd= false;

    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(playerCharacter == null )
        {
            UnityEngine.Debug.Log("�÷��̾ ã�� �� ����");
        }
        

    }


    void Update()
    {
        if(!isTransform && skullNpcTalkEnd == gameManager.talkIndex)
        {
            isTransform = true ;
            UnityEngine.Debug.Log("����");

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
            UnityEngine.Debug.Log("���� �Ϸ�");
            skullMonster.SetActive(true);
            Destroy(gameObject);
        }


    }


    
}
