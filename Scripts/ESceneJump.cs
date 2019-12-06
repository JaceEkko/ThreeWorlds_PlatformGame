using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESceneJump : MonoBehaviour {

	public Rigidbody2D rd;
	public bool onGround = true;

	public int jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { //end game jump animation for all the animals (I got smarter)
		Vector3 vel = rd.velocity;
		if (onGround == true) {
			onGround = false;
			vel.y = jump;

		} 
		rd.velocity = vel;
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Platform") {
			Debug.Log (coll.gameObject.name);
			onGround = true;

		} 
	}
}
