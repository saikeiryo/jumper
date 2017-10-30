using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private InputField mainInputField;

    // Use this for initialization
    void Start ()
    {
        mainInputField = GameObject.Find("InputField").GetComponent<InputField>();
        mainInputField.text = PlayerPrefs.GetString("input1");


        StartCoroutine(InsAll());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Ins()
    {
        string insertScoreURL = "https://jumpgame13.000webhostapp.com/insProc1.php";

        WWWForm form = new WWWForm();
        form.AddField("namePost", PlayerPrefs.GetString("input1"));
        form.AddField("scorePost", PlayerPrefs.GetInt("Score1"));

        WWW www = new WWW(insertScoreURL, form);
        yield return www;
    }

    IEnumerator InsAll()
    {
        string insertScoreURL = "https://jumpgame13.000webhostapp.com/insAllProc.php";

        WWWForm form = new WWWForm();
        form.AddField("namePost", PlayerPrefs.GetString("input1"));
        form.AddField("scorePost", PlayerPrefs.GetInt("Score1"));
        form.AddField("rPost", PlayerPrefs.GetInt("r1"));
        form.AddField("bPost", PlayerPrefs.GetInt("b1"));
        form.AddField("gPost", PlayerPrefs.GetInt("g1"));
        form.AddField("pPost", PlayerPrefs.GetInt("p1"));

        WWW www = new WWW(insertScoreURL, form);
        yield return www;
    }
}