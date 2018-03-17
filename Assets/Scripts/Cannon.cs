using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {

	public GameObject ballPrefab;
	public int maximumBalls = 3;
	// new ball velocity parameters
	public float throwSpeed = 10;
	public float throwSpeedVariation = 5;
	// new ball direction parameters
	public float horizontalAngularRange = 40;
	public float upwardAngularRange = 15;
	
	Queue<GameObject> balls = new Queue<GameObject>();

	// initialization
	void Start () {
		// makes object on the scene moving below this threshold stop
		Physics.sleepThreshold = 1.0f;

		if (ballPrefab == null)
			Debug.LogError ("Cannon.cs: a ballPrefab must be defined");
	}
	
	// Update is called once per frame
	void Update () {
		// destroy balls if exceeding the maximum allowed
		while (balls.Count > maximumBalls) {
			GameObject destroyBall = balls.Dequeue ();
			Destroy(destroyBall);
		}

		// Fire1 (usually left click) fire a new ball
		if (Input.GetButtonUp ("Fire1"))
			FireNewBall ();
	}

	void FireNewBall (){
		// create ne ball
		GameObject newBall = Instantiate (ballPrefab, this.transform.position, this.transform.localRotation) as GameObject;
		balls.Enqueue (newBall);

		// get new ball rigid body and set the throwing direction and velocity
		Rigidbody rb = newBall.GetComponent<Rigidbody>();
		if (rb != null) {
			float horChange = UnityEngine.Random.Range(0.0f, horizontalAngularRange) - horizontalAngularRange/2.0f;
			float vertChange = UnityEngine.Random.Range(0.0f, upwardAngularRange);
			Vector3 direction = Quaternion.Euler(-vertChange, horChange, 0) *  Vector3.forward;
			rb.velocity = this.transform.TransformDirection(direction * UnityEngine.Random.Range(throwSpeed - throwSpeedVariation, throwSpeed + throwSpeedVariation));
		}
	}
}
