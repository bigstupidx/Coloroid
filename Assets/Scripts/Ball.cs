using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private int ballColor = 1;
	private int spriteShape = 0;
	public Sprite[] ballSprite;

	// Use this for initialization
	void Start () {
		ballColor = Random.Range (1,4);
		spriteShape = Random.Range (0,3);
		ChangeBallColor ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = ballSprite [spriteShape];
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
