using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour {

	public bool pressed = false;

	void Start(){
	}

	void Update(){

		title ();
	}

	void title(){
		if (Input.GetKey (KeyCode.Space)) { //starts the game when the spacebar is tapped
			pressed = true;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene");
		}
	}
}
