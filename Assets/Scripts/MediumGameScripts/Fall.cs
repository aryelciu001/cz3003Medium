using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");
        GameObject gamedata = GameObject.Find("GameData");
        player.GetComponent<charMove>().restart();
        gamedata.GetComponent<Loader>().gameMgr.GetComponent<GameMgr>().decLifeCount();
    }
}
