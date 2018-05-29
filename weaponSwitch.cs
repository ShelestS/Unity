using UnityEngine;

public class weaponSwitch : MonoBehaviour {
	public int selectedW = 0;
	// Use this for initialization
	void Start () {
		SelectW ();
	}
	
	// Update is called once per frame
	void Update () {

		int previousSelectedW = selectedW;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
			if (selectedW >= transform.childCount - 1)
				selectedW = 0;
			else
				selectedW++;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
			if (selectedW <= 0)
				selectedW = transform.childCount-1;
			else
				selectedW--;
		}

		if (Input.GetKeyDown (KeyCode.Alpha1) && transform.childCount>=2) {
			selectedW = 0;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && transform.childCount>=2) {
			selectedW = 1;
		}

		if (previousSelectedW != selectedW) {
			SelectW ();
		}
	}
	void SelectW(){
		int i = 0;
		foreach (Transform weapon in transform) {
			if (i == selectedW)
				weapon.gameObject.SetActive (true);
			else
				weapon.gameObject.SetActive (false);
			i++;

		}
	}
}
