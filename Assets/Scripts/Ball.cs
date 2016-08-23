using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private int ballColor = 1;
	private int numbersOfColor = 6;

	// Use this for initialization
	void Start () {
		ballColor = Random.Range (1, numbersOfColor+1);
		ChangeBallColor ();
	}

	private void ChangeBallColor() {
		switch(ballColor) {
		case 1:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			break;
		case 2:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		case 3:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
			break;
		case 4:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			break;
		case 5:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
			break;
		case 6:
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.magenta;
			break;
		}
	}

	public int GetBallColor() {
		return ballColor;
	}
}
