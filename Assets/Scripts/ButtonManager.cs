using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

public void StartBtn(string firstTry1)
    {
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("YourBestScore", 0);

        Debug.Log(PlayerPrefs.GetString("input1") + " - " + PlayerPrefs.GetInt("Score1"));
        SceneManager.LoadScene(firstTry1);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void ResultsBtn(string score)
    {
        SceneManager.LoadScene(score);
    }

    public void ReturnBtn(string goBack)
    {
        SceneManager.LoadScene(goBack);   
    }

    public void GetInput(string input)
    {
        PlayerPrefs.SetString("input1", input);
    }

    public void exitBtn(string menu)
    {
        OnGUI2D.oG2D.SaveScore();
        Debug.Log(PlayerPrefs.GetString("input1") + " - " + PlayerPrefs.GetInt("Score1"));
        //StartCoroutine(OnGUI2D.oG2D.InsertScr(PlayerPrefs.GetString("input1"), PlayerPrefs.GetInt("Score1")));

        StartCoroutine(Ins());
        SceneManager.LoadScene(menu);
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
}