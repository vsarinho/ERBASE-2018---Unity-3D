using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl_2 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float mh = Input.GetAxis ("Horizontal");
		float mv = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (mh, 0.0f, mv);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("colidiu!!");
		if (other.gameObject.tag == "Pick Up")
		{
			other.gameObject.SetActive (false);
		}
	}
}
