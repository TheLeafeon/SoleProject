using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullNpc : MonoBehaviour
{
    public GameManager gameManager;
    //대화가 끝나는 타이밍
    public int skullNpcTalkEnd = 5;
    bool isTransform = false;


    void Update()
    {
        if(!isTransform && skullNpcTalkEnd == gameManager.talkIndex)
        {
            isTransform = true ;
            UnityEngine.Debug.Log("변신");
        }
    }


    
}
