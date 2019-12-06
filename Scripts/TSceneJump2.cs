using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSceneJump2 : MonoBehaviour {

	public Rigidbody2D rd;
	public bool onGround = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () { //the bunny title scene jump same as when he jumps in his level
		Vector3 vel = rd.velocity;
		if (onGround == true) {
			onGround = false;
			vel.y = 8;
		} 
		rd.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "BPlat") {
			Debug.Log (coll.gameObject.name);
			onGround = true;

		} 
	}
}
