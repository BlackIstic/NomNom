using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlacidlo : MonoBehaviour
{
    private InfoPanel inf=null; //panel na výpis bodov
    private GameObject objekt = null; //objekt na načítatnie infopanela 

    public string Miestnost ;
    // Start is called before the first frame update
    void Start()
    {
        //Application.LoadLevel (Miestnost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transport (){
        objekt= GameObject.Find ("Infopanel"); // načíta infopanel do objektu
		inf = objekt.GetComponent (typeof(InfoPanel)) as InfoPanel;// pretipuje objekt na infopanel
		inf.Nova_Hra(); // zavolá funkciu infopanela na načítanie bodov 
        Application.LoadLevel (Miestnost);

    }
}
