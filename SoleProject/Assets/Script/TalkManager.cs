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
        talkData.Add(1, new string[] { "���", "���� 1����������" });

    }

    public string GetTalk(int stageNumber, int talkIndex)
    {
        return talkData[stageNumber][talkIndex];
    }
}
