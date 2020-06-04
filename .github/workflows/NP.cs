using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class NP : MonoBehaviour {
 
    public float rychlost = 7f;  //rýchlosť nepriateľa
    public Vector2 smer_na_zaciatku = new Vector2(4f, 7f); //smer nepriateľa 
    public LayerMask maska_stien; // maska stien od ktorých sa nepriateľ odráža
 
    private Rigidbody2D rb;  //vlastnosť označujúca pevnosť objektu neslúži na určenie kolízií
 
    // keď je postavička zobudená
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // vezmi si komponent "pevné telo"
        rb.velocity = smer_na_zaciatku.normalized * rychlost; //vlastnosť objektu slúžiava na pohyb
        // definuje sa pomocou vlastností narozdiel od pohybu postavičky ktorý sa určuje na 
        //základe vstupu z klávesnice
    }
 
    // pri zrážke z objektom
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
            
        //zmena vektora pri odraze od steny
        Vector2 towardsCollision = collision.contacts[0].point - (Vector2)transform.position;
        Ray2D ray = new Ray2D(transform.position, towardsCollision);


        
    }
}