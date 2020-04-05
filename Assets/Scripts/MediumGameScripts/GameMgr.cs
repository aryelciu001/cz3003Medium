using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance = null;
    private int lifeCount = 5;
    private int noQuestions = 5;
    private int correctAns = 0;
    private int score = 0;

    private GameObject scoreText;
    private GameObject lifeCountText;

    public int getScore()
    {
        return score;
    }

    public int getLifeCount()
    {
        return lifeCount;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        
        
    }

    public int getCorrectAnswer()
    {
        return correctAns;
    }
    public void decLifeCount()
    {
        if(--lifeCount <= 0)
        {
            gameOver();
        }
        else
        {
            lifeCountText = GameObject.Find("LifeCount");
            lifeCountText.GetComponent<LifeCount>().changeLifeCount();
        }
    }
    public void decNoQuestions()
    {
        score += 500;
        if (--noQuestions <= 0)
        {
            gameOver();
        }else
        {
            scoreText = GameObject.Find("ScoreText");
            scoreText.GetComponent<Score>().changeScore();
            nextStage();
        }
    }
    public void gameOver()
    {
        SceneManager.LoadScene("MediumGameOver");
    }
    public void nextStage()
    {
        SceneManager.LoadScene("MediumGameScene");
    }
    public int getNoQuestion()
    {
        return noQuestions;
    }
}
