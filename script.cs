using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManegement;
public class script : MonoBehaviour {
	public float speedo = 6.0F;
	public float jumpSpeed = 8.0F; 
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	float q;
	float m;
	float n;
	Rigidbody rb;//передвижение
	Transform tr;//изменение
	Rigidbody clone;
	//Camera mycam;
	public Rigidbody obj;
	public Transform dulo; 
	/*public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;*/
	// Use this for initialization
	private float speed = 2.0f;
	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;
	float MouseX;
	float MouseY;
	Animator anim;
	[HideInInspector] public float CurrentTargetSpeed = 8f;
	public float ForwardSpeed = 2.0f;   // Speed when walking forward
	public float BackwardSpeed = 1.5f;  // Speed when walking backwards
	public float StrafeSpeed = 4.0f;    // Speed when walking sideways
	public float RunMultiplier = 6f;   // Speed when sprinting
	public KeyCode RunKey = KeyCode.LeftShift;
	public float JumpForce = 30f;
	public void UpdateDesiredTargetSpeed(Vector2 input)
	{
	}
	public GameObject Obj = null;
	public Vector3 jump;
	public float jumpForce = 2.0f;

	public bool isGrounded;
	void Start () {
		rb = GetComponent <Rigidbody> ();
		tr = GetComponent <Transform> ();
		anim = GetComponent<Animator> ();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		//mycam = GetComponent<Camera>();
		//c = GetComponent < CapsuleCollider> ();
	}
	void OnCollisionStay()
	{
		isGrounded = true;
	}
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown("Fire1")){
			clone = Instantiate (obj, dulo.position, tr.rotation);
			clone.GetComponent<Rigidbody>().AddForce(tr.forward * 5000f);
			//rigidbody.AddRelativeForce (Vector3.forward * 10);
		}*/
		q = Input.GetAxis ("Vertical");//0,-1,1,,onclick



		//sword

		if (Input.GetButtonDown("Fire1")){
			//anim.SetFloat("isattack",5);
			Debug.Log ("ABEETEEI");
		}


		if (Input.GetKey (KeyCode.D)) {
			transform.position += tr.right * ForwardSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += -tr.right * ForwardSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += tr.forward * ForwardSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += -tr.forward * BackwardSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Debug.Log("RUN");
			ForwardSpeed = 4f;
			BackwardSpeed = 3f;
			Debug.Log(speed);
			//m_Running = true;
		}
		else
		{
			ForwardSpeed = 2f;
			BackwardSpeed = 1.5f;
		}
		var x = Input.GetAxis ("Mouse X");
		var y = Input.GetAxis ("Mouse Y");
		if (x != MouseX || y != MouseY) {
			rotationX += x * sensX * Time.deltaTime;
			rotationY += y * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			MouseX = x;
			MouseY = y;
			Obj.transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}


	}


}