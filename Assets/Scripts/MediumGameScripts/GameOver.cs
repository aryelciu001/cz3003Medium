using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameMgr gamemgr;
    private int lifeCount;
    private int score;
    private int time;
    private int bonus = 100;
    private void Start()
    {
        gamemgr = GameObject.Find("GameData").GetComponent<Loader>().gameMgr.GetComponent<GameMgr>();
        lifeCount = gamemgr.getLifeCount();
        score = gamemgr.getScore();
        switch (this.name)
        {
            case "TotalScore":
                GetComponent<Text>().text = "Score: " + score.ToString();
                break;
            case "RemainingLife":
                GetComponent<Text>().text = "Remaining Life: " + lifeCount.ToString();
                break;
            case "BonusScore":
                GetComponent<Text>().text = "Bonus Score: " + lifeCount.ToString();
                break;
            case "TimeUsed":
                GetComponent<Text>().text = "TimeUsed: " + lifeCount.ToString();
                break;
            default:
                break;
        }
    }
}
