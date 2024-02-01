using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBar : MonoBehaviour
{
    public static UIHpBar instance { get; private set; }


    public Image[] hp = new Image[5]; 


    void Awake()
    {
        instance = this;
    }

    public void SetHp(int nowHp)
    {
        for(int hpLoop = 0; hpLoop < hp.Length; hpLoop ++)
        {
            //체력 감소
            if(hpLoop < nowHp)
            {
                 hp[hpLoop].GetComponent<Image>().enabled = true;
                UnityEngine.Debug.Log(hpLoop + " 하트 표시");
            }
            else
            {
                hp[hpLoop].GetComponent<Image>().enabled = false;
                UnityEngine.Debug.Log(hpLoop + " 하트 숨기기");
            }
        }
    }
}
//SetHp로 받아오는 변수는 0,1,2,3,4,5
//5면 4 까지 전부 true여야 하고
//0이면 0까지 false여야 함