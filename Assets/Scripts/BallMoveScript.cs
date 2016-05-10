using UnityEngine;
using System.Collections;

public class BallMoveScript : MonoBehaviour {
	public float speed = 5;

	void Start() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f)) * speed;
	}
}
