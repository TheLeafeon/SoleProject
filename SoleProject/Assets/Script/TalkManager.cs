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
        talkData.Add(1, new string[] { "어서와", "여긴 1스테이지야", "저기 오른쪽 맵 끝까지 가면 다음 스테이지로 갈 수 있어", "행운을 빌어" });
        talkData.Add(2, new string[] { "안녕", "여기는 2스테이지야", "저 하늘 위에 있는 포탈을 찾으면 다음 스테이지로 갈 수 있어","하늘 위로 어떻게 가냐고?", "구름을 밟으면 또 한번 점프할 수 있으니 그걸 이용해봐" });
        talkData.Add(3, new string[] { "반가워..", "3스테이지에 온걸 환영해..","3스테이지는 간단해 나한테서 끝까지 도망치면 성공이야 쉽지..?", "준비 됐어..?", "그럼 시작할게..." });

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
