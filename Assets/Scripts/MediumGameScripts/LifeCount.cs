using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    Text text;
    GameObject gamemgr;

    private void Start()
    {
        gamemgr = GameObject.Find("GameData");
        text = GetComponent<Text>();
        text.text = gamemgr.GetComponent<Loader>().gameMgr.GetComponent<GameMgr>().getLifeCount().ToString();
    }

    public void changeLifeCount()
    {
        text.text = gamemgr.GetComponent<Loader>().gameMgr.GetComponent<GameMgr>().getLifeCount().ToString();
    }
}
