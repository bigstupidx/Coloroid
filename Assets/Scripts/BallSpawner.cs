using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {
	public GameObject prefabBall;
	private float respawnTime = 2.56f;
	private float lastTime = 0.0f;

	void Update() {
		if (Time.time > (lastTime + respawnTime)) {
			CreateBall ();
			lastTime = Time.time;
			respawnTime -= 0.002f; // uber z respawn time kazde vytvorenie novej gulicky
			print (respawnTime);
		}
	}
		
	private void CreateBall() {
		Instantiate (prefabBall, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
	}

	public void SetGravitySpeed(float gravitySpeed) {
		prefabBall.GetComponent<Rigidbody2D> ().gravityScale = gravitySpeed;
	}
}
