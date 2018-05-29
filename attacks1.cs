using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks1 : MonoBehaviour {
	Animator anim;
	public float damage = 50f;
	public float range = 15f;
	public float impactForce=50f;
	float attackRate = 15f;
	private float nextTimeToAttack = 0f;
	public Camera fpsCam;
	public GameObject impactEffect;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		///
		//nextTimeToAttack = Time.time + 1f / attackRate;
		///
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2")){
			anim.SetBool("atacking",true);
			StartCoroutine (Test());
			//anim.Play("isattack");
		}
		/*if (Input.GetButtonDown("Fire1")){
			//anim.SetFloat("isattack",5);
			//Debug.Log ("ABEETEEI");
			//anim.Play("isattack");
		}*/
	}
	void endtresk(){

	}
	IEnumerator Test(){
		yield return new WaitForSeconds (1);
		Debug.Log ("WAITIN");
		anim.SetBool("atacking",false);
		Debug.Log ("ATTACK");
		Swish ();
	}
	void Swish(){
		RaycastHit hit;
		if(Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
			Debug.Log (hit.transform.name);
			Target target = hit.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}

			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			Destroy bottle = hit.transform.GetComponent<Destroy> ();
			if (bottle != null) {
				bottle.TakeDamage (damage);
			}

			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			GameObject impactGO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGO, 2f);
		}
	}
}
