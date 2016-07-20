using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	private GameObject switchColor;
	private int rocketColor = 2; // green

	// Use this for initialization
	void Start () {
		switchColor = GameObject.FindGameObjectWithTag ("SwitchColor");
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Ball") {
			if(rocketColor == 0) {
				print("uhuuuu");
				Destroy(coll.gameObject);
			} else {
				print("smola");
				Destroy(coll.gameObject);
			}
			//coll.gameObject.GetComponent<GameFieldAnimator> ().AnimateField ();
			///StartCoroutine (BallScale());
			/*if (turnBall) {
				turnBall = false;
			} else {
				turnBall = true;			
			}*/
		}
	}
}
