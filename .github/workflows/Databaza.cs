using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite; // kniznice potrebna pre pracu sqlite databazou
using System.Data;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Databaza : MonoBehaviour
{


    private Text tabID; //text objekt pre vypis poradia
    private Text tabmeno;  //text objekt pre vypis mien
    private Text tabscore; //text objekt pre vypis score
    private GameObject objekt = null; //objekt na nacitanie prvkov UI
    public string Miestnost;
    private int i = 1; // na zaciatku jedna lebo nie je nulty hrac ale az prvy
    // Start is called before the first frame update
    void Start()
    {
        objekt = GameObject.Find("ID");  // nacitanie textovych poli pre vypis tabulky
        tabID = objekt.GetComponent(typeof(Text)) as Text;
        objekt = GameObject.Find("TabulkaMeno");
        tabmeno = objekt.GetComponent(typeof(Text)) as Text;
        objekt = GameObject.Find("TabulkaScore");
        tabscore = objekt.GetComponent(typeof(Text)) as Text;


        string conn = "URI=file:" + Application.dataPath + "/Databaza.db"; //Premenna na nacitanie miesta databazy
        IDbConnection dbconn; // premenna na nadviazanie spojenia s databazou
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //otvorenie komunikacie s databazou

        string sqlQuery; //premenna na ukladanie prikazov pre pracu s databazou



        IDbCommand dbcmd = dbconn.CreateCommand(); // vytvorenie ulohy
        dbcmd.CommandType = System.Data.CommandType.Text;
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS 'Highscore' ( " +
                          "  'Name' TEXT NOT NULL, " +
                          "  'Body' INTEGER NOT NULL" +
                          ");";
        dbcmd.ExecuteNonQuery();


        sqlQuery = "SELECT Name, Body " + "FROM Highscore ORDER BY Body Desc LIMIT 10"; // nacitaj meno a body z tabulky highscore zoradeny podla score a limitovany na desat prvkov 
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader(); //vykonanie citania


        while (reader.Read()) //kym cita
        {

            string meno = reader.GetValue(0).ToString().Trim(); //meno hraca
            string body = reader.GetValue(1).ToString().Trim(); //body hraca
            tabID.text = tabID.text + "\n" + i; //vypis id 
            i++;
            tabmeno.text = tabmeno.text + "\n" + meno; //vypis meno hraca 
            tabscore.text = tabscore.text + "\n" + body; //vypis pocet bodov
            //Debug.Log("  meno =" + meno + "  body =" + body); //vypis
        }
        reader.Close(); // nasledovne je vyprazdnenie a ukoncenie premennych
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    
}
