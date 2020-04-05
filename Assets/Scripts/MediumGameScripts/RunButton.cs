using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton : MonoBehaviour
{
    public void startRun()
    {
        DropPlace bridge = GameObject.Find("AnswerPlace").GetComponent<DropPlace>();
        charMove player = GameObject.Find("Player").GetComponent<charMove>();
        QuestionMgr question = GameObject.Find("Question").GetComponent<QuestionMgr>();
        if (!player.getStart() && !bridge.getIsEmpty() && question.getIsReady())
        {
            player.startRunFunc();
        }
    }
}
