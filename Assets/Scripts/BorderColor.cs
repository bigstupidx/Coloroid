using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour {
	public Text scoreText;
	private int rocketColor = 1; // green
	private Color[] colors = new Color[6];

	// Use this for initialization
	void Start () {
		colors[0] = Color.cyan;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = Color.blue;
		colors[4] = Color.yellow;
		colors[5] = Color.magenta;
		gameObject.GetComponent<MeshFilter> ().mesh.colors = colors;//[Random.Range(0, colors.Length)];
		//rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
	}

	/*void OnCollisionEnter2D(Collision2D coll) {
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
	}*/
}
