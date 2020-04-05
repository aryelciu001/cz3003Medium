using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderQuestion : MonoBehaviour
{
    public GameObject fetchQuestions;
    private void Awake()
    {
        if (FetchQuestions.instance == null)
        {
            Instantiate(fetchQuestions);
        }
    }
}
