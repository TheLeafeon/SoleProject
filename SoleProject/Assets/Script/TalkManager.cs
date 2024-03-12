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
        talkData.Add(2, new string[] { "드르렁...", "엇.. 누구야...", "그래그래 너구나 그 시험을 치루러 온 사람이란게", "시험은 간단해 저 하늘 위 어딘가에 있는 포탈 속으로 들어가면 끝이야", "어? 하늘을 어떻게 나냐고?", "하늘을 날 순 없지만 높이 뛸 수 있는 방법을 알려주지", "점프를 해서 구름 속에 들어가면 또 다시 점프를 할 수 있어", "그렇게 구름을 타고 이리저리 이동하면서 포탈을 찾아봐", "여기 새들은 나랑은 달리 난폭해서 공격적이니까 잘 피해서 다니도록 해", "그럼 이제 알아서 해봐.  난 더 자야겠어" });

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
