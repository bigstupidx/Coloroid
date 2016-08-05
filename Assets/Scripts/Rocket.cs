using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {
	private GameObject switchColor;
	public Text scoreText;
	private int rocketColor = 2; // green
	private int gameScore = 0; 
	private float ballGravity = 0.2f;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("BallSpawner").GetComponent<BallSpawner> ().SetGravitySpeed (ballGravity);
		switchColor = GameObject.FindGameObjectWithTag ("SwitchColor");
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
		if(coll.gameObject.tag == "Ball") {
			if(rocketColor == coll.gameObject.GetComponent<Ball>().GetBallColor()) {
				gameScore++;
				scoreText.text = gameScore.ToString();
				CheckScore ();
				Destroy(coll.gameObject);
			} else {
				scoreText.text = "game over";
				Destroy(coll.gameObject);
			}
		}
	}

	private void CheckScore() {
		ballGravity += 0.01f;
		GameObject.FindGameObjectWithTag ("BallSpawner").GetComponent<BallSpawner> ().SetGravitySpeed (ballGravity);

		switch(gameScore) {
			case 10:
				switchColor.GetComponent<SwitchColor> ().SetNumberOfColor (4);
			break;
			case 20:
				switchColor.GetComponent<SwitchColor> ().SetNumberOfColor (5);
			break;
			case 40:
				switchColor.GetComponent<SwitchColor> ().SetNumberOfColor (6);
			break;
		}
	}
}
