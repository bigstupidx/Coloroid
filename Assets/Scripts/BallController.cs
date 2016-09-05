using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.y <= (Screen.height - (Screen.height / 4))) { // 4 cast obrazovky bude neaktivna na dotyk
				if (Input.mousePosition.x <= (Screen.width / 2)) {
					this.transform.Rotate (0,0,90f);
				} else {
					this.transform.Rotate (0,0,-90f);
				}
			}
		}
	}
}
