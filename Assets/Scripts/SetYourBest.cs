using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetYourBest : MonoBehaviour {

    public string[] scoreS;

    // Use this for initialization
    IEnumerator Start () {
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
                break;
            }
        }
        if (PlayerPrefs.GetInt("Score1") > PlayerPrefs.GetInt("YourBestScore"))
        {
            PlayerPrefs.SetInt("YourBestScore", PlayerPrefs.GetInt("Score1"));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
