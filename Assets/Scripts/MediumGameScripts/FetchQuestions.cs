using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System;
using System.Threading.Tasks;

public class FetchQuestions : MonoBehaviour
{
    //private string[] questions = { "a=2 \nb=3 \na-b=?", "a=3 \nb=4 \na-b=?", "a=4 \nb=5 \na-b=?", "a=2 \nb=3 \na-b=?", "a=2 \nb=3 \na-b=?" };
    private List<String> questions = new List<String>(new string[] { "element1"});
    private string[][] answers = { new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" }, new string[3] { "-1", "-2", "-3" } };
    private int[] correctAnswers = { 0, 0, 0, 0, 0 };

    public static FetchQuestions instance = null;
    private bool done = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cz3003gamedata.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        fetchDatafromDB();
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
        print("fetch data from db called");
        FirebaseDatabase.DefaultInstance.GetReference("Medium").ValueChanged += HandleValueChanged;
        Debug.Log("kelihatan ga di sini");
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        print("handle value changed called");

        DataSnapshot qnssnapshot = e.Snapshot.Child("Topic1").Child("Question");
        //List<String> qnslist = new List<String>();
        //Read all qns in DB
        foreach (DataSnapshot qn in qnssnapshot.Children)
        {
            questions.Add(qn.GetValue(true).ToString());
            print(qn.GetValue(true).ToString());
        }
        // Set questions with qnslist retrieved from DB
        //questions = qnslist;




        print("qnlist size inside handlevaluechanged" + questions.Count);

        done = true;
        print("handle value changed done");

    }






    public string getQuestions(int index)
    {
        print("get qn called");
        print(index);
        print("qnslist size" + questions.Count.ToString());
        print(questions[0]);
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
