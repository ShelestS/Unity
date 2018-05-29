
using UnityEngine;

public class Gun : MonoBehaviour {

	// Use this for initialization
	public float bullets = 10;
	public float damage = 10f;
	public float range = 100f;
	public float impactForce=50f;
	float fireRate = 15f;
	public Camera fpsCam;
	public ParticleSystem flash;
	public GameObject impactEffect;
	Animator anim;
	private float nextTimeToFIre = 0f;
	// Update is called once per frame
	void Start () {
		anim = GetComponent<Animator> ();
		///
		//nextTimeToAttack = Time.time + 1f / attackRate;
		///
	}
	void Update () {
		if (bullets < 0) {
			bullets=0;
		}
		if (Input.GetButton ("Fire1") && Time.time >= nextTimeToFIre) {
			if (bullets > 0) {
				nextTimeToFIre = Time.time + 1f / fireRate;
				Shoot ();
				anim.SetBool ("isShootin", true);
				bullets--;
			} else {
				Debug.Log ("No Ammo");
			}
		} else {
			Check ();
		}
	}
	void Check(){
		anim.SetBool("isShootin",false);
	}
	void Shoot(){
		flash.Play();
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
