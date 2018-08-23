using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAvatar : MonoBehaviour {

	private Animator anim;
	private float v;
	private float h;
	private float sprint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Sprinting ();
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("walk", v);
		anim.SetFloat ("turn", h);
		anim.SetFloat ("sprint", sprint);

		if (Input.GetButton ("Jump")) {
			GetComponent<Animator>().enabled = false;
			//Destroy (gameObject, 2);
		}
	}

	void Sprinting(){
		if (Input.GetButton ("Fire1")) {
			sprint = 0.2f;
		} 
		else {
			sprint = 0.0f;
		}
		//Debug.Log ("sprint:"+sprint);
	}
}
