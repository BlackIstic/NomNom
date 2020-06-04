using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bod : MonoBehaviour
{

    public int body;  //počet bodov za hranolku
	private InfoPanel inf=null; //panel na výpis bodov
    private GameObject objekt = null; //objekt na načítatnie infopanela 
    public GameObject nepriatel = null; //objekt nepriateľ 
    public GameObject nepriatel1 = null;
    public GameObject nepriatel2 = null; //objekt nepriateľ 
   // public GameObject nepriatel3 = null;

    void OnEnable (){ //ak funguje ignoruje nepriateľov s nimi kolízia nič nerobí 
        Physics2D.IgnoreCollision(nepriatel.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(nepriatel1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(nepriatel2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //    Physics2D.IgnoreCollision(nepriatel3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
	{

		print("OnCollisionEnter2D : " + collision.gameObject.name); // výpis na debugovanie

		if ("macman".Equals(collision.gameObject.name)){ // ak sa zrazí s macmanom 

			objekt= GameObject.Find ("Infopanel"); // načíta infopanel do objektu
			inf = objekt.GetComponent (typeof(InfoPanel)) as InfoPanel;// pretipuje objekt na infopanel
			inf.Boduj (body); // zavolá funkciu infopanela na načítanie bodov 

			 //Pošle bod na pozíciu mimo plochy čo je spôsob akým ho odstrániť z plochy 
            transform.position = transform.position + new Vector3(100000,100000,100000);

            //výpis na debugovanie 
            Debug.Log(transform.position);

        }

	}
}
