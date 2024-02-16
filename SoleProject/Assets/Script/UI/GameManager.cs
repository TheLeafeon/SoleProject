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
           UnityEngine.Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
           Destroy(gameObject);
        
        }
    }

    void Update()
    {
        if(!isOpenUI && Input.GetButtonDown("Cancel")) 
        {
            UnityEngine.Debug.Log("UI����");
            isOpenUI = true;
        }
    }

}
