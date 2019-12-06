using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	public SpriteRenderer sr;
	public Sprite port;
	public playerController play;


	public void exit(playerController p){ //once the portal activates, depending on what scene you are on, will teleport you to the next level
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene2");
		}
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene2")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene3");
		}
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene3")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("EndScene");
		}
	}
}
