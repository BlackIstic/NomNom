using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialny2 : MonoBehaviour
{
    public GameObject nepriatel = null; //objekt nepriateľ 
    public GameObject nepriatel1 = null;//objekt nepriateľ1 
    public GameObject nepriatel2 = null;//objekt nepriateľ2
   // public GameObject nepriatel3 = null;//objekt nepriateľ3 
    public macman_pohyb hrac = null; // objekt macman ale nazvaný inak 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable (){ //ak funguje ignoruje nepriateľov s nimi kolízia nič nerobí 
        Physics2D.IgnoreCollision(nepriatel.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(nepriatel1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(nepriatel2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      //  Physics2D.IgnoreCollision(nepriatel3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
	{

		print("OnCollisionEnter2D : " + collision.gameObject.name + "specialny"); // výpis na debugovanie

		if ("macman".Equals(collision.gameObject.name)){ // ak sa zrazí s macmanom 
            //pošle bod mimo plochy čo je spôsob akým ho odstrániť z plochy 
            transform.position = transform.position + new Vector3(100000,100000,100000);
 
            hrac.rychlost= 20; 
            // zavolaj funkciu ktorá počká 15 sekúnd 
            StartCoroutine(Pockaj());


            //výpis na debugovanie 
            Debug.Log(transform.position);

        }

	}

    IEnumerator Pockaj ()
    {
        //Vypíš čas pri zavolaní
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //počkaj na 15 sekúnd reálneho (nie strojového) času 
        yield return new WaitForSecondsRealtime(15);
        hrac.rychlost= 10; 
        //Po piatich sekundách vypíš čas 
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
