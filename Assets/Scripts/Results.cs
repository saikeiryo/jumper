using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Data;
//using System.Data.SqlClient;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;


public class Results : MonoBehaviour
{

    public string[] score;

    string dbstring = "";

    private IEnumerator MySQLSelect()
    {
        WWW dbData = new WWW("http://localhost/sai_db/dbData.php");
        yield return dbData;
        string dbScore = dbData.text;
        Debug.Log(dbScore);
    }



    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SelectPr());


        //StartCoroutine(SelectR());

    }

    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void InsertProc()
    {
        /*string oradb = "Data Source=(DESCRIPTION=" +
            "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" +
            "(CONNECT_DATA =" +
              "(SERVER = DEDICATED)" +
              "(SERVICE_NAME = XE)));" +
              "USER Id = sai; Password = sai;";
        OracleConnection connection = new OracleConnection(oradb);

        connection.Open();
        Debug.Log("Connected!");
        OracleCommand cmd = connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "testInsert";
        cmd.Connection = connection;

        OracleParameter parNameIn = new OracleParameter();
        OracleParameter parScoreIn = new OracleParameter();

        parNameIn.ParameterName = "NAME";
        parNameIn.OracleDbType = OracleDbType.Varchar2;
        parNameIn.Size = 32;
        parNameIn.Direction = ParameterDirection.Input;
        parNameIn.Value = i_name;
        cmd.Parameters.Add(parNameIn);

        parScoreIn.ParameterName = "SCORE";
        parScoreIn.OracleDbType = OracleDbType.Decimal;
        parScoreIn.Size = 32;
        parScoreIn.Direction = ParameterDirection.Input;
        parScoreIn.Value = i_score;
        cmd.Parameters.Add(parScoreIn);

        cmd.ExecuteNonQuery();
        Debug.Log("Inserted!"); */

        //connection.Close();
    }

    private void InsertMSProc(string name, int score)
    {
        /*string _conString = "Data Source=127.0.0.1; Initial Catalog=ms_sai_db;User ID=sa;Password=Microlab1";
        SqlConnection conn = new SqlConnection(_conString);
            conn.Open();
            Debug.Log("Connected!");

         SqlCommand cmd = new SqlCommand("testInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@p_score", SqlDbType.Int).Value = score;

                conn.Open();
                Debug.Log("Connected!");
                cmd.ExecuteNonQuery(); */


    }

    IEnumerator SelectPr()
    {
        //WWW dbData = new WWW("http://localhost/sai_db/selectProc.php");
        WWW dbData = new WWW("https://jumpgame13.000webhostapp.com/selectProc.php");
        yield return dbData;
        string dbScore = dbData.text;
        print(dbScore);
        score = dbScore.Split(';');
        print(GetDataValue(score[0], "Score:"));

        //Debug.Log(System.Environment.Version);

        string textScore = "";
        string textScore2 = "";
        Text highText = GameObject.Find("1").GetComponent<Text>();
        Text highText2 = GameObject.Find("2").GetComponent<Text>();
        //highText.text = "1. " + PlayerPrefs.GetString("input1") + " - " + PlayerPrefs.GetInt("HighScore1");
        for (int i = 0; i < 5; i++)
        {
            int j = i + 1;
            textScore = textScore + j + ". " + GetDataValue(score[i], "Name:") + "\n\n";
            textScore2 = textScore2 + GetDataValue(score[i], "Score:") + "\n\n";
        }
        //Debug.Log(textScore);
        highText.text = textScore;
        highText2.text = textScore2;
        //string first = GetDataValue(score[0], "Name:");
        //highText.text = "1. " + first;
    }

    IEnumerator SelectR()
    {
        string insertScoreURL = "https://jumpgame13.000webhostapp.com/selectR.php";

        WWWForm form = new WWWForm();
        form.AddField("rPost", GetDataValue(score[0], "Name:"));

        WWW www = new WWW(insertScoreURL, form);
        yield return www;
        dbstring = dbstring + www.text + "\n\n";
        print(dbstring);
        //score = dbScore.Split(';');
        //print(GetDataValue(score[0], "Score:"));

        string textR = "";
        Text uTextR = GameObject.Find("R").GetComponent<Text>();
        uTextR.text = uTextR.text + dbstring;
        //highText.text = "1. " + PlayerPrefs.GetString("input1") + " - " + PlayerPrefs.GetInt("HighScore1");
    }
}
