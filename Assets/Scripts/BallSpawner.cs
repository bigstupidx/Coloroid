using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {
	public GameObject prefabBall;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateBall", 2f, 2f);
	}
		
	private void CreateBall() {
		Instantiate (prefabBall, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
	}
}
