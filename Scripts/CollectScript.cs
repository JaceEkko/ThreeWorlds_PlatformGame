using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour {

	public SpriteRenderer sr1; //item sprite renderer
	public SpriteRenderer sr2; //item sprite renderer
	public BoxCollider2D bc;

	public AudioSource AS;
	public AudioClip AC;

	public void collect(playerController p){ //once the item is collected the sprites disappear and the box collider is disabled
		sr1.sprite = null;
		sr2.sprite = null;
		bc.enabled = false;

		AS.PlayOneShot (AC);

		p.pts -= 1;

		p.pointsLeft.text = p.pts.ToString(); //subtracts one from the total number of collectibles on the level
	}
}
