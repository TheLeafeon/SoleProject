using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "���", "���� 1����������", "���� ������ �� ������ ���� ���� ���������� �� �� �־�", "����� ����" });
        talkData.Add(2, new string[] { "�帣��...", "��.. ������...", "�׷��׷� �ʱ��� �� ������ ġ�緯 �� ����̶���", "������ ������ �� �ϴ� �� ��򰡿� �ִ� ��Ż ������ ���� ���̾�", "��? �ϴ��� ��� ���İ�?", "�ϴ��� �� �� ������ ���� �� �� �ִ� ����� �˷�����", "������ �ؼ� ���� �ӿ� ���� �� �ٽ� ������ �� �� �־�", "�׷��� ������ Ÿ�� �̸����� �̵��ϸ鼭 ��Ż�� ã�ƺ�", "���� ������ ������ �޸� �����ؼ� �������̴ϱ� �� ���ؼ� �ٴϵ��� ��", "�׷� ���� �˾Ƽ� �غ�.  �� �� �ھ߰ھ�" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];

        }
        
    }
}
