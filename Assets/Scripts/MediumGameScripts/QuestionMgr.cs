using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMgr : MonoBehaviour
{
    //hardcoded 
    private string question= "a=2 \nb=3 \na-b=?";
    private string[] answers = { };
    private int correctAns = -1;
    private bool isReady = false;
    private GameMgr gamemgr;
    private FetchQuestions fetch;

    private void Start()
    {
        gamemgr = GameObject.Find("GameData").GetComponent<Loader>().gameMgr.GetComponent<GameMgr>();
        fetch = GameObject.Find("Fetcher").GetComponent<LoaderQuestion>().fetchQuestions.GetComponent<FetchQuestions>();
        fetchData();
    }

    private void fetchData()
    {
        question = fetch.getQuestions(gamemgr.getNoQuestion() - 1);
        answers = fetch.getAnswers(gamemgr.getNoQuestion() - 1);
        correctAns = fetch.getCorrectAns(gamemgr.getNoQuestion() - 1);
        isReady = true;
        startingGame();
    }

    private void startingGame()
    {
        GetComponent<Text>().text = question;
        Bridge bridge = GameObject.Find("Bridge").GetComponent<Bridge>();
        GameObject[] ansboxes = GameObject.FindGameObjectsWithTag("answerbox");
        int index;
        foreach(GameObject ansbox in ansboxes)
        {
            index = int.Parse(ansbox.name.Substring(2));
            ansbox.GetComponent<AnswerBox>().receiveAnswers(answers[index]);
        }
        bridge.receiveCorrectAns(correctAns);

    }

    public bool getIsReady()
    {
        return isReady;
    }
}
