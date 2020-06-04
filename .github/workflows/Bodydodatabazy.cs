using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;  // kniznice potrebna pre pracu sqlite databazou
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI; 

public class Bodydodatabazy : MonoBehaviour
{
    private InfoPanel inf = null; //panel na výpis bodov
    private GameObject objekt = null; //objekt na načítatnie objektov ako su infopanel a inputfield 
    private string meno = null; //premenna pre ulozenie zadaneho mena
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zmenmeno(InputField userInput)
    {
        //Debug.Log(userInput.text);
        meno = userInput.text; //priradenie stringu podla zadaneho mena


    }

    

    public void Zapis()
    {
        objekt = GameObject.Find("Infopanel"); // načíta infopanel do objektu
        inf = objekt.GetComponent(typeof(InfoPanel)) as InfoPanel;// pretipuje objekt na infopanel
 


        string conn = "URI=file:" + Application.dataPath + "/Databaza.db"; //Premenna na nacitanie miesta databazy
        IDbConnection dbconn; // premenna na nadviazanie spojenia s databazou
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //otvorenie komunikacie s databazou
        string sqlQuery;

        IDbCommand dbcmd = dbconn.CreateCommand(); // vytvorenie ulohy
        dbcmd.CommandType = System.Data.CommandType.Text;
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS 'Highscore' ( " +
                          "  'Name' TEXT NOT NULL, " +
                          "  'Body' INTEGER NOT NULL" +
                          ");";
        dbcmd.ExecuteNonQuery();


        sqlQuery = "INSERT INTO Highscore " + "Values ('" + meno + "'," + inf.body + ")"; //vloz udaje do tabulky
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery(); //vykonaj ulohu
        //Debug.Log("  name =" + meno + "  body =" + inf.body);

        dbcmd.Dispose(); //ukoncenie komunikacie a vyprazdnenie premennych
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
}
