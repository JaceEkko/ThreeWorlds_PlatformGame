using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnScript : MonoBehaviour {

	public void respawn(playerController p){ //if you hit the map edge (deathbox) the game restarts
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene");
		}
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene2")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene2");
		}
		if (UnityEngine.SceneManagement.Scene.Equals (p.currScene, "GameScene3")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene3");
		}
	}
}
