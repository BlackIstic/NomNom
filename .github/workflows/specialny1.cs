using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialny1 : MonoBehaviour
{
    public GameObject nepriatel = null; //objekt nepriateľ 
    public GameObject nepriatel1 = null;
    public GameObject nepriatel2 = null;//objekt nepriateľ2
   // public GameObject nepriatel3 = null;//objekt nepriateľ3 
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
     //   Physics2D.IgnoreCollision(nepriatel3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
	{

		print("OnCollisionEnter2D : " + collision.gameObject.name + "specialny"); // výpis na debugovanie

		if ("macman".Equals(collision.gameObject.name)){ // ak sa zrazí s macmanom 
            //pošle bod mimo plochy čo je spôsob akým ho odstrániť z plochy 
            transform.position = transform.position + new Vector3(100000,100000,100000);
            //Pošle nepriatelov na pozíciu mimo plochy čo je spôsob akým ho odstrániť z plochy 
            nepriatel.transform.position = new Vector3(200000,200000,200000);
            nepriatel1.transform.position = new Vector3(300000,300000,300000);
            nepriatel2.transform.position = new Vector3(200000, 200000, 200000);
         //   nepriatel3.transform.position = new Vector3(300000, 300000, 300000);
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
        // vráť nepriateľov do hry na pozíciu na ktorej začínali 
        nepriatel.transform.position = new Vector3(-1.78f,-11.29f ,0);
        nepriatel1.transform.position = new Vector3(1.4f,12,0);
        nepriatel2.transform.position = new Vector3(-1.78f, 12, 0);
       // nepriatel3.transform.position = new Vector3(1.4f, 12, 0);
        //Po piatich sekundách vypíš čas 
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
