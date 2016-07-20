using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private int ballColor = 1;
	// Use this for initialization
	void Start () {
		ballColor = Random.Range (1,4);
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
		}
	}

	public int GetBallColor() {
		return ballColor;
	}
}
