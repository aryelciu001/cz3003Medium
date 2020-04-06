using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System;
using System.Threading.Tasks;

public class FetchQuestions:MonoBehaviour
{
    public static FetchQuestions instance = null;
    //private string[] questions = { "a=2 \nb=3 \na-b=?", "a=3 \nb=4 \na-b=?", "a=4 \nb=5 \na-b=?", "a=2 \nb=3 \na-b=?", "a=2 \nb=3 \na-b=?" };
    private List<String> questions = new List<String>(new string[] { "element1", "element1" , "element1" , "element1" , "element1" , "element1" , "element1" });
    private string[][] answers = { new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" } };
    private int[] correctAnswers = { 0, 0, 0, 0, 0 };

    private bool done = false;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("Initialized");
            instance = this;
            // Set up the Editor before calling into the realtime database.
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cz3003gamedata.firebaseio.com/");
            // Get the root reference location of the database.
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            fetchDatafromDB();
        }
        else if (instance != this)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (done)
        {
            if (SceneManager.GetActiveScene().name == "MediumLoading")
            {
                SceneManager.LoadScene("MediumGameScene");
            }
        }
    }

    private void fetchDatafromDB()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Medium").ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        DataSnapshot qnssnapshot = e.Snapshot.Child("Topic1").Child("Question");
        //List<String> qnslist = new List<String>();
        //Read all qns in DB
        foreach (DataSnapshot qn in qnssnapshot.Children)
        {
            questions.Add(qn.GetValue(true).ToString());
        }
        // Set questions with qnslist retrieved from DB
        //questions = qnslist;
        foreach (string qn in questions)
        {
            Debug.Log(qn);
        }
        done = true;
    }

    public string getQuestions(int index)
    {
        foreach (string qn in questions)
        {
            Debug.Log(qn);
        }
        return questions[index];
    }
    public string[] getAnswers(int index)
    {
        return answers[index];
    }
    public int getCorrectAns(int index)
    {
        return correctAnswers[index];
    }
}
