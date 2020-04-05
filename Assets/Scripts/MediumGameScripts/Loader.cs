using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameMgr;
    private void Awake()
    {
        if(GameMgr.instance == null)
        {
            Instantiate(gameMgr);
        }
    }
}
