using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public float health=10f;
	public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0f) {
			Die ();
		}
	}
	void Die(){
		//Destroy (gameObject);
		Instantiate (destroyedOne, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	// Use this for initialization
	public GameObject destroyedOne;
	
	// Update is called once per frame
	/*void OnMouseDown () {
		Instantiate (destroyedOne, transform.position, transform.rotation);
		Destroy (gameObject);
	}*/
}
