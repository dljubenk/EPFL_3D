using UnityEngine;
using System.Collections;

public class Football : MonoBehaviour {
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb  = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Player") {
			rb.velocity = rb.velocity*1.3f;
		}
	}

}
