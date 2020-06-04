using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    static bool created = false ; // bol panel vytvorený 
	public int body; // počet bodov 
	public Text Hodnotenie; // text na výpis hodnotenia 
    //public level= 1;

    // funkcia slúžiaca na vytvorenie objektu
    void Start () { 
		body = 0; // začiatočný počet bodov 
		vypisBody (); // zavolá funkciu na výpis bodov definovanú nižšie 
	}

    //zavolá sa pri načítaní objektu napr. pri načítaní nového levelu 
	void Awake (){
		if (!created) { // ak nieje vytvorený ( v tomto leveli )
			DontDestroyOnLoad (transform.gameObject);// vytvor ho pomocou funkcie DontDestroyOnLoad 
            //takže akoby ani nezmizol a bol stále ten istý ako v predošlom leveli 
			created = true; // zapíš že je vytvorený 
		} else {
			Destroy (transform.gameObject); // inak ho znič aby tam náhodou neboli dva 
		}
	}

    public void vypisBody (){
		string o = body.ToString (); //premeň číslo body na text
		Hodnotenie.text = o; //vypisuje body do textu na obrazovke 

	}

    

    public void Boduj (int kolko){
		body += kolko; //k aktuálnemu množstvu bodov pripíš body získané za udalosť ktorá funkciu volá
        vypisBody (); // zavolá funkciu na výpis bodov definovanú vyššie 

		if (body == 234) {
            Application.LoadLevel ("level2");
        } 
        if (body == 600) {
            Application.LoadLevel ("vyhra");
        } 
	
	}

    public void Nova_Hra (){
        body=0;
        vypisBody (); 
    }
}
