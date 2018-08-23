using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public Transform player;

	public float awareDistance = 5.0f; 
	public float scaredDistance = 10.0f; 
	 
	enum AIStatus {idle = 0, aware = 1, scared = 2} 
	private AIStatus status = AIStatus.idle;

	private Animator anim;

	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void SetPlayer(GameObject g){
		player = g.transform;
	}
	
	// Update is called once per frame
	void Update () {
		CheckStatus();
		 
		switch(status) {
			case AIStatus.idle:
				Idle();
				break;

			case AIStatus.aware:
				Avoid();
				break;

			case AIStatus.scared:
				RunAway();
				break;
		}
	}

	void CheckStatus() { 
		float dist = (player.position - transform.position).magnitude;

		if (dist < scaredDistance) {
			status = AIStatus.scared;
		}
		else if (dist >= scaredDistance && dist <= awareDistance){
			status = AIStatus.aware;
		}
		else if (dist > awareDistance){
			status = AIStatus.idle;
		}
		
	}

	void Idle() { 
		anim.SetBool ("idle", true);
		anim.SetBool ("walk", false);
		anim.SetBool ("run", false);
	}

	void Avoid() { 
		anim.SetBool ("idle", false);
		anim.SetBool ("walk", true);
		anim.SetBool ("run", false);

	}

	void RunAway() { 
		anim.SetBool ("idle", false);
		anim.SetBool ("walk", false);
		anim.SetBool ("run", true);
	}
}
