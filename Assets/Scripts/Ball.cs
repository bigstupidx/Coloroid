using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private int ballColor = 1;
	private int spriteShape = 0;
	public Sprite[] ballSprite;
	private int numbersOfColor = 7;

	// Use this for initialization
	void Start () {
		numbersOfColor = GameObject.FindGameObjectWithTag ("SwitchColor").GetComponent<SwitchColor>().GetNumberOfColor();
		print (numbersOfColor);
		ballColor = Random.Range (1, numbersOfColor+1);
		spriteShape = Random.Range (0, 3);
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
