using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public float backgroundSound_Volume = 1.0f;
    public float effectSound_Volume = 1.0f;

    public GameObject soundUI;

    bool isOpenUI = false;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
           UnityEngine.Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
           Destroy(gameObject);
        
        }
    }

    void Update()
    {
        if(!isOpenUI && Input.GetButtonDown("Cancel")) 
        {
            UnityEngine.Debug.Log("UI오픈");
            isOpenUI = true;
        }
    }

}
