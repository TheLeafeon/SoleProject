using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullNpc : MonoBehaviour
{
    public GameManager gameManager;
    //��ȭ�� ������ Ÿ�̹�
    public int skullNpcTalkEnd = 5;
    bool isTransform = false;


    void Update()
    {
        if(!isTransform && skullNpcTalkEnd == gameManager.talkIndex)
        {
            isTransform = true ;
            UnityEngine.Debug.Log("����");
        }
    }


    
}
