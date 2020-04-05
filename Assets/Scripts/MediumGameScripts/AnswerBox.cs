using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBox : MonoBehaviour
{
    // Start is called before the first frame update
    string ans = "";

    void Start()
    {
        Vector2 velocity = new Vector2(Random.Range(-150f, 150f), Random.Range(-150f, 150f));
        GetComponent<Rigidbody2D>().velocity = velocity;
        Text text = GetComponentInChildren<Text>();
        text.text = ans;
    }

    public void receiveAnswers(string theans)
    {
        ans = theans;
        Text text = GetComponentInChildren<Text>();
        text.text = ans;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
