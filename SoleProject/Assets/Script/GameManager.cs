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

    public void Action(int StageNumber)
    {

        talkText.text = "�������� " + StageNumber + " �Դϴ�.";
    }
    

}
