using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl_3 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	public Text countText;
	public Text winText;
	
	private int count;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
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
		//Debug.Log("ok2");
		if (other.gameObject.tag == "Pick Up")
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 3)
		{
			winText.text = "You Win!";
		}
	}
	
}
