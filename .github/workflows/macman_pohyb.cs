using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macman_pohyb : MonoBehaviour {

	public float rychlost=10; // nastav rýchlost panáčika 
  
    // Use this for initialization
    void Start () {
		
	}

	// Update je volaný v pravidelných intervaloch 
	void Update () {
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) 
		//ak hráč stlačí šípku do prava alebo do ľava 
		{
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * rychlost * Time.deltaTime, 0f, 0f));
			//posuň hráča v horizontálnom smere 
		}

		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		//ak hráč stlačí šípku hore alebo dole 
		{
			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * rychlost * Time.deltaTime, 0f));
			//posuň hráča vo vertikálnom smere 
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		print("OnCollisionEnter2D : " + collision.gameObject.name); // výpis na debugovanie
       

        if (collision.gameObject.name.Contains ("nepriatel")){ // ak sa zrazí s macmanom 
			Application.LoadLevel ("koniec");

        }

	}
}
