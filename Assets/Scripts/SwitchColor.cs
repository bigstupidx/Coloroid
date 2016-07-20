using UnityEngine;
using System.Collections;

public class SwitchColor : MonoBehaviour {
	public GameObject middleRocket;
	public GameObject leftRocket;
	public GameObject rightRocket;
	private int rocketColor = 2;
	private int actualColorPallete = 1;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x <= Screen.width / 2) {
				actualColorPallete++;
				if(actualColorPallete <= 3) {
					ChangeColor (actualColorPallete);
				} else {
					actualColorPallete = 1;
					ChangeColor (actualColorPallete);
				}
			} else {
				print ("right");
				actualColorPallete--;
				if(actualColorPallete >= 1) {
					ChangeColor (actualColorPallete);
				} else {
					actualColorPallete = 3;
					ChangeColor (actualColorPallete);
				}
			}
		}
	}

	private void ChangeColor(int colorPallete) {
		switch(colorPallete) {
			case 1:
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				actualColorPallete = 1;
				rocketColor = 2;
			break;
			case 2:
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				actualColorPallete = 2;
				rocketColor = 3;
				break;
			case 3:
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
			    middleRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				actualColorPallete = 3;
				rocketColor = 1;
				break;
		}
	}

	public int GetRocketColor () {
		return rocketColor;
	}
}
