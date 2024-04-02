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
        talkData.Add(2, new string[] { "�ȳ�", "����� 2����������", "�� �ϴ� ���� �ִ� ��Ż�� ã���� ���� ���������� �� �� �־�","�ϴ� ���� ��� ���İ�?", "������ ������ �� �ѹ� ������ �� ������ �װ� �̿��غ�" });
        talkData.Add(3, new string[] { "�ݰ���..", "3���������� �°� ȯ����..","3���������� ������ �����׼� ������ ����ġ�� �����̾� ����..?", "�غ� �ƾ�..?", "�׷� �����Ұ�..." });

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
