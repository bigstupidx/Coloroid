using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			//if (Input.mousePosition.y <= Screen.height / 2) {
				if (Input.mousePosition.x <= Screen.width / 2) {
					transform.Rotate (0,0,90f);
				} else {
					transform.Rotate (0,0,-90f);
				}
			//}
		}
	}
}
