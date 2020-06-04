using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybNP3 : MonoBehaviour
{
    public float rychlost = 7f;//rýchlosť nepriateľa
    private Vector2 target; //vektor pre pohyb
    private GameObject objekt; //objekt na nacitanie prvkov UI

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f); //priradenie nuloveho vektora
    }

    void FixedUpdate()
    {
        objekt = GameObject.FindGameObjectWithTag("macman"); //nacitanie objektu hraca pre neskorsie zistenie polohy
        float krok = rychlost * Time.deltaTime; // velkost kroku
        target = objekt.transform.position; //poloha hraca
        transform.position = Vector2.MoveTowards(transform.position, target, krok); //pohyb za hracom

    }

    //skopirovane z NP
    private void OnCollisionEnter2D(Collision2D collision)
    {


        //zmena vektora pri odraze od steny
        Vector2 towardsCollision = collision.contacts[0].point - (Vector2)transform.position;
        Ray2D ray = new Ray2D(transform.position, towardsCollision);



    }
}
