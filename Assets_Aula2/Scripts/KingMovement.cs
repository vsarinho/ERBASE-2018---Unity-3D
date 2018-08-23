using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour {

	private Animator anim;
	int hIdle;
	int hForward;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		hIdle = Animator.StringToHash ("Idle");
		hForward = Animator.StringToHash ("Forward");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetButtonDown ("Jump")) {

			Debug.Log ("Jump ok");

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Armature|_Idle")) {
				anim.SetBool (hIdle, false);
				anim.SetBool (hForward, true);
				Debug.Log ("Foward ok");
			}
		}
		else {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Armature|_Idle")) {
				anim.SetBool(hIdle, true);
				anim.SetBool(hForward, false);
				Debug.Log("Idle ok");
			}
		}
	
	
	}
}
