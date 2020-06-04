using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybNP2 : MonoBehaviour
{

    public Transform[] waypoints = null; // pole bodov sluziacich pre pohyb
    int cur = 0; // pocitadlo pre zistenie ku ktoremu bodu sa ma nepriatel pohybovat
    public float rychlost = 7f; //rýchlosť nepriateľa

    private Rigidbody2D rb; //vlastnosť označujúca pevnosť objektu neslúži na určenie kolízií
    public float distance = 1f; //vyhovujuca vzdialenost od boda
                               
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        var direction = Vector2.zero; //priradenie nuloveho vektora
        direction = waypoints[cur].transform.position - transform.position; //priradenie destinacie pohybu

        if (direction.magnitude < distance) //ak je vzdialenost od bodu vyhovujuca
        {
            if (cur < waypoints.Length - 1) //neprisiel k poslednemu bodu pola bodov sluziacich pre pohyb
            {
                cur++;
            }
            else //je na konci pola preto zacne odzaciatku
            {
                cur = 0;
            }
        }
        direction = direction.normalized; //normalizacia 
        Vector2 dir = direction; 
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * rychlost, direction.y * rychlost); //pohyb na bod
    }


    //skopirovane z NP
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        //zmena vektora pri odraze od steny
        Vector2 towardsCollision = collision.contacts[0].point - (Vector2)transform.position;
        Ray2D ray = new Ray2D(transform.position, towardsCollision);



    }
}
