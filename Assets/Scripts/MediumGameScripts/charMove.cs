using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool start = true;
    private bool isRun = false;
    private Vector2 stopRun = new Vector2(0, 0);
    private Vector2 startRun = new Vector2(5, 0);
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = startRun;
    }

    // Update is called once per frame
    void Update()
    {
        if(start) //game still starting
        {
            if(GetComponent<Transform>().position.x >= 7.5)
            {
                GetComponent<Rigidbody2D>().velocity = stopRun;
                start = false;
            }
        }
    }

    public bool getStart()
    {
        return start;
    }

    public void startRunFunc()
    {
        if (!isRun)
        {
            GetComponent<Rigidbody2D>().velocity = startRun;
        }
        isRun = true;
    }

    public void restart()
    {
        GetComponent<Transform>().position = new Vector3(1.2f, 7.37f, -2f);
        start = true;
        isRun = false;
    }
}
