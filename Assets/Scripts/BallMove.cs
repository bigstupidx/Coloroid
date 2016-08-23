using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {
	public float ballSpeed = 2.0f;
	public bool turnBall = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnBall) {
			transform.Translate (0, ballSpeed * Time.deltaTime, 0);
		} else {
			transform.Translate (0, -ballSpeed * Time.deltaTime, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "BorderCollider") {
			//StartCoroutine (BallScale());
			if (turnBall) {
				turnBall = false;
			} else {
				turnBall = true;			
			}
		}
	}

	/*IEnumerator BallScale() {
		iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(0.15f,0.15f,0.15f),"time", 0.25f, "easetype", iTween.EaseType.linear));
		yield return new WaitForSeconds(0.15f);
		iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(0.13f,0.13f,0.13f),"time", 0.25f, "easetype", iTween.EaseType.linear));
	}*/
}
