using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {
	private GameObject switchColor;
	public Text scoreText;
	private int rocketColor = 2; // green

	// Use this for initialization
	void Start () {
		switchColor = GameObject.FindGameObjectWithTag ("SwitchColor");
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		rocketColor = switchColor.GetComponent<SwitchColor> ().GetRocketColor ();
		if(coll.gameObject.tag == "Ball") {
			if(rocketColor == coll.gameObject.GetComponent<Ball>().GetBallColor()) {
				print("uhuuuu");
				scoreText.text = "juhuuu";
				Destroy(coll.gameObject);
			} else {
				scoreText.text = "doriti";
				Destroy(coll.gameObject);
			}
		}
	}
}
