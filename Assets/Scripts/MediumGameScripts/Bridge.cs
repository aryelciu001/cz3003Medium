using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private bool ansCorrect = false;

    private int correctAswer = -1;

    public void receiveCorrectAns(int correctIndex)
    {
        correctAswer = correctIndex;
    }

    void Update()
    {
        if (!ansCorrect)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void receiveAnswer(int ans)
    {
        if(ans == correctAswer)
        {
            ansCorrect = true;
        }
    }
}
