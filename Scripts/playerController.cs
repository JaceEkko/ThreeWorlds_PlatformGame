using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public string currScene; //used to determine what set of mechanics to use depending on the scene you are in

	public Rigidbody2D rd;

	//jump booleans
	public bool onGround = false; //resets the jump count for the fox
	public bool DJump = true; //used for bunny

	//instruction variables
	public bool instruct = true;
	public TextMesh instructions;

	//Vector3 res = transform.position;

	//Sprite variables
	public SpriteRenderer spr;
	public Sprite fly; //used for the owl when hes flying
	public Sprite stay; //normal/default sprite

//	public bool left = false;
//	public bool right = false;

	//public bool rolling = false;

	public TextMesh pointsLeft;
	public int pts = 19;

	public bool startPortal = false;

	public SpriteRenderer portal;
	public Sprite port;

	public AudioSource AS;
	public AudioClip jump; //jump sound
	public AudioClip djump;
	public AudioClip nxtlvlopen; //tell you when the portal is open to progress
	//public AudioClip s;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		spr = GetComponent<SpriteRenderer> ();

//		res.x = -0.14;
//		res.y = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//All three movement mechanics are the same except for the verticle movements
		//THE FOX MECHANICS
		if (UnityEngine.SceneManagement.Scene.Equals (currScene, "GameScene")) { //move and a single jump
			//Song.PlayOneShot (s);
			Vector3 vel = rd.velocity;
			if (Input.GetKey (KeyCode.LeftArrow)) {
				vel.x = -5;
				//rolling = true;

				//left = true;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				vel.x = 5;
				//rolling = true;

				//right = true;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow) && onGround == true) { //one jump
				vel.y = 5;
				instruct = false;
				AS.PlayOneShot (jump);
			} 
			rd.velocity = vel;

			if (pts == 0) { //activates portal so you can move onto next level
				portal.sprite = port;
				AS.PlayOneShot (nxtlvlopen);
			}
		}

		//THE RABBIT MECHANICS
		if (UnityEngine.SceneManagement.Scene.Equals (currScene, "GameScene2")) { //move and a double jump
			//Song.PlayOneShot (s);
			Vector3 vel = rd.velocity;
			if (Input.GetKey (KeyCode.LeftArrow)) {
				vel.x = -5;

			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				vel.x = 5;

			}
			if (Input.GetKeyDown (KeyCode.UpArrow) && onGround == true) {
				vel.y = 5;
				instruct = false;
				AS.PlayOneShot (jump);
			} 
			if (Input.GetKeyDown (KeyCode.UpArrow) && onGround == false && DJump == true) { //double jump
				vel.y = 14;
				DJump = false;
				AS.PlayOneShot (djump);
			} 
			rd.velocity = vel;

			if (pts == 0) {
				portal.sprite = port;
				AS.PlayOneShot (nxtlvlopen);
			}
		}

		//THE OWL MECHANICS
		if (UnityEngine.SceneManagement.Scene.Equals (currScene, "GameScene3")) { //move and flight
			Vector3 vel = rd.velocity;
			if (Input.GetKey (KeyCode.LeftArrow)) {
				vel.x = -5;

			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				vel.x = 5;

			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) { //got rid of the onGround boolean, so player can repeatidly tap up arrow to fly
				vel.y = 5;
				instruct = false;
				//spr.sprite = roll;
				AS.PlayOneShot (jump);
			} 
			rd.velocity = vel;

			if (onGround == true) {
				spr.sprite = stay;
			} else {
				spr.sprite = fly;
			}

			if (pts == 0) {
				portal.sprite = port;
				AS.PlayOneShot (nxtlvlopen);
			}
		}

		if (instruct == false) {
			instructions.text = "";
		}
	}


	void OnCollisionEnter2D(Collision2D coll){ //resets single jump boolean
		if (coll.gameObject.name == "Platform") {
			Debug.Log (coll.gameObject.name);
			onGround = true;

			startPortal = true;
		} 

	}


	void OnTriggerEnter2D(Collider2D coll){ //calls most of the other scripts once triggered
		
		CollectScript cs = coll.gameObject.GetComponent<CollectScript> (); //activates upon touching a collectible
		if (cs != null) {
			cs.collect (this);
		}

		respawnScript rs = coll.gameObject.GetComponent<respawnScript> (); //actiavtes upon hitting the map edge
		if (rs != null) {
			rs.respawn (this);
		}

		ExitScript es = coll.gameObject.GetComponent<ExitScript> (); //activates upon hitting the portal to leave the level
		if (es != null && pts == 0) {
			es.exit (this);
		}
		
	}

	void OnCollisionExit2D(Collision2D coll){ //makes it so you can't jump more than once by disabling the onGround boolean
		if (coll.gameObject.name == "Platform") {
			onGround = false;
			DJump = true;
		} 
	}
}
