using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float reach = 100;
	//public float shootPower = 10;
	public float killAfter = 5;

	private LineRenderer line;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray target = new Ray (transform.position,transform.forward);

		line.SetPosition(0, transform.position);
		line.SetPosition(1, transform.position);

		//Debug.Log ("transform.position:"+transform.position+ "transform.forward * reach:"+(transform.forward* reach));
		if (Input.GetKeyDown (KeyCode.X)) {
			Debug.Log ("X");
			//Debug.DrawRay (transform.position, transform.forward * reach, Color.green);

			line.SetPosition(1, transform.forward * reach);

			if (Physics.Raycast (target, out hit, reach)) {
				Debug.Log ("Ray:"+hit.collider.gameObject.tag);

				if (hit.collider.gameObject.tag == "Enemy") {
					Debug.Log ("Enemy");

					hit.collider.gameObject.GetComponent<Animator>().enabled = false;
					//hit.collider.gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * shootPower);
					Destroy (hit.collider.gameObject, killAfter);
				}
			}
		}
	}
}
