using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSceneJump3 : MonoBehaviour {

	public Rigidbody2D rd;
	public bool onGround = true;

	public SpriteRenderer sr;
	public Sprite fly;
	public Sprite notFly;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () { //the owl title scene jump same as when he jumps in his level
		Vector3 vel = rd.velocity;
		if (onGround == true) {
			onGround = false;
			vel.y = 6;
			sr.sprite = fly;
		} 
		rd.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "PPlat") {
			Debug.Log (coll.gameObject.name);
			onGround = true;
			sr.sprite = notFly;
		} 
	}
}
