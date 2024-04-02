using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public bool isAction;
    public int talkIndex;
    NpcManager npcManager;

    public void Action(GameObject scanNpc)
    {

        npcManager = scanNpc.GetComponent<NpcManager>();
        Talk(npcManager.id);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        


        //대화 끝나면
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;

            return;
        }

        talkText.text = talkData;

        isAction = true;
        talkIndex++;
    }
}
