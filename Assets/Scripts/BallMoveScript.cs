using UnityEngine;
using System.Collections;

public class BallMoveScript : MonoBehaviour {
	private Vector2 screenSize;
	private float xSpeed;
	private float ySpeed;
	private float maxSpeed = 3.0f;
	private float minSpeed = -3.0f;
	private Vector2 move;

	void Start () {
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) / 2.0f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.height, 0))) / 2.0f;
		xSpeed = UnityEngine.Random.Range (minSpeed, maxSpeed);
		ySpeed = UnityEngine.Random.Range (minSpeed, maxSpeed);
	}

	void Update() {
		if ((this.transform.position.x > (screenSize.x - (this.transform.localScale.x / 2.0))) || (this.transform.position.x < -screenSize.x + (this.transform.localScale.x / 2.0))) {
			xSpeed = -xSpeed;
		}

		if ((this.transform.position.y > (screenSize.y - (this.transform.localScale.y / 2.0))) || (this.transform.position.y < -screenSize.y + (this.transform.localScale.y / 2.0))) {
			ySpeed = -ySpeed;
		}
			
		move.x = xSpeed * Time.deltaTime;
		move.y = ySpeed * Time.deltaTime;
		transform.Translate (move);
	}
}