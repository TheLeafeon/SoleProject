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
            //ü�� ����
            if(hpLoop < nowHp)
            {
                 hp[hpLoop].GetComponent<Image>().enabled = true;
                UnityEngine.Debug.Log(hpLoop + " ��Ʈ ǥ��");
            }
            else
            {
                hp[hpLoop].GetComponent<Image>().enabled = false;
                UnityEngine.Debug.Log(hpLoop + " ��Ʈ �����");
            }
        }
    }
}
//SetHp�� �޾ƿ��� ������ 0,1,2,3,4,5
//5�� 4 ���� ���� true���� �ϰ�
//0�̸� 0���� false���� ��