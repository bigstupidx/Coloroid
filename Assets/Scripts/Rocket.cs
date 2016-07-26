using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {
	private GameObject switchColor;
	public Text scoreText;
	private int rocketColor = 2; // green
	private int gameScore = 0; 

	// Use this for initialization
	void Start () {
		switchColor = GameObject.FindGameObjectWithTag ("SwitchColor");
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
		if(coll.gameObject.tag == "Ball") {
			if(rocketColor == coll.gameObject.GetComponent<Ball>().GetBallColor()) {
				gameScore++;
				scoreText.text = gameScore.ToString();
				Destroy(coll.gameObject);
			} else {
				scoreText.text = "game over";
				Destroy(coll.gameObject);
			}
		}
	}
}
