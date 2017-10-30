using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnGUI2D : MonoBehaviour
{
    public static OnGUI2D oG2D;
    public static int score;
    int highScore;
    int bestscore;

    Text scoreText;
    Text highText;
    Text yourbest;

    //lets see
    public string[] scoreS;

    // Use this for initialization
    void Start ()
    {
        bestscore = 0;

        oG2D = this;
	    score = 0;
	    highScore = PlayerPrefs.GetInt("HighScore1");

        Debug.Log("!!!!!!!!!!!!!!" + score + "   " + highScore);

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        highText = GameObject.Find("HighText").GetComponent<Text>();
        yourbest = GameObject.Find("YourBest").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    scoreText.text = "Score: " + score;
	    highText.text = "HighScore: " + highScore;
	    yourbest.text = "Your best: " + PlayerPrefs.GetInt("YourBestScore");

	}

    void OnGUI()
    {
        //GUI.Label(new Rect(10,10,100,20), "Score: " + score);
        //GUI.Label(new Rect(10, 30, 100, 20), "HighScore: " + highScore);
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            Debug.Log("Saving Score");
            PlayerPrefs.SetInt("HighScore1", score);
        }
    }

    public int GetScore()
    {
        return highScore;
    }

    IEnumerator InsertScr()
    {
        //string insertScoreURL = "http://localhost/sai_db/insProc.php";
        string insertScoreURL = "https://jumpgame13.000webhostapp.com/insProc.php";

        WWWForm form = new WWWForm();
        form.AddField("namePost", PlayerPrefs.GetString("input1"));
        form.AddField("scorePost", PlayerPrefs.GetInt("Score1"));

        WWW www = new WWW(insertScoreURL, form);
        yield return www;

        Debug.Log(www.text);
    }

    void OnApplicationQuit()
    {
        SaveScore();
        StartCoroutine(InsertScr());
    }

    public void SaveScore()
    {
        if (score > PlayerPrefs.GetInt("Score1"))
        {
            PlayerPrefs.SetInt("Score1", score);
        }
    }

    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    IEnumerator InsYourBest()
    {
        //HighScore search and insert
        WWW dbData = new WWW("https://jumpgame13.000webhostapp.com/selectProc.php");
        yield return dbData;
        string dbScore = dbData.text;
        scoreS = dbScore.Split(';');
        for (int i = 0; i < scoreS.Length; i++)
        {
            if (GetDataValue(scoreS[i], "Name:").Equals(PlayerPrefs.GetString("input1")))
            {
                PlayerPrefs.SetInt("YourBestScore", Int32.Parse(GetDataValue(scoreS[i], "Score:")));
            }
            else
            {
                PlayerPrefs.SetInt("YourBestScore", 0);
            }

        }
    }
}