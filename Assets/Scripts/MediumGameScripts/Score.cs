using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int numQuestion = 5;
    private GameObject gamedata;

    private void Start()
    {
        gamedata = GameObject.Find("GameData");
        GetComponent<Text>().text = "Score: " + gamedata.GetComponent<Loader>().gameMgr.GetComponent<GameMgr>().getScore().ToString();
    }

    public void changeScore()
    {
        GetComponent<Text>().text = "Score: " + gamedata.GetComponent<Loader>().gameMgr.GetComponent<GameMgr>().getScore().ToString();
    }
}
