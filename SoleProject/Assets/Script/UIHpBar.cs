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

    public void SetHp(float nowHp)
    {
        for(int hpLoop = 0; hpLoop < hp.Length; hpLoop ++)
        {
            //체력 감소
            if(nowHp <= hpLoop)
            {
                hp[hpLoop].GetComponent<Image>().enabled = false;
                //UnityEngine.Debug.Log("UICount-1");
            }
        }
    }
}
