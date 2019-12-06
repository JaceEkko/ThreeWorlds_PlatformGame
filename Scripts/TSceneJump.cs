using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSceneJump : MonoBehaviour {

	public Rigidbody2D rd;
	public bool onGround = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { //the fox title scene jump same as when he jumps in his level
		Vector3 vel = rd.velocity;
		if (onGround == true) {
			onGround = false;
			vel.y = 4;
		} 
		rd.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "OPlat") {
			Debug.Log (coll.gameObject.name);
			onGround = true;

		} 

	}
}
