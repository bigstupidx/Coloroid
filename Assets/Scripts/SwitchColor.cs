using UnityEngine;
using System.Collections;

public class SwitchColor : MonoBehaviour {
	public GameObject middleRocket;
	public GameObject leftRocket;
	public GameObject rightRocket;
	private int numberOfColors = 3; 
	private int rocketColor = 2;
	private int actualColorPallete = 1;
	// RGBWOM
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x <= Screen.width / 2) {
				actualColorPallete++;
				if(actualColorPallete <= numberOfColors) {
					ChangeColorRocket (numberOfColors, actualColorPallete); 
				} else {
					actualColorPallete = 1;
					ChangeColorRocket(numberOfColors, actualColorPallete);
				}
			} else {
				print ("right");
				actualColorPallete--;
				if(actualColorPallete >= 1) {
					ChangeColorRocket(numberOfColors, actualColorPallete);
				} else {
					actualColorPallete = numberOfColors;
					ChangeColorRocket(numberOfColors, actualColorPallete);
				}
			}
		}
	}

	private void ChangeColorRocket(int numberOfColors, int colorPallete) {
		switch(numberOfColors) {
		case 3: //////////////////////////////////////33333333333333333//////////////////////////////////
			switch(colorPallete) {
			case 1:// RGB
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				actualColorPallete = 1;
				rocketColor = 2;
				break;
			case 2: //GBR
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				actualColorPallete = 2;
				rocketColor = 3;
				break;
			case 3://BRG
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				actualColorPallete = 3;
				rocketColor = 1;
				break;
			}
			break;
		case 4://////////////////////////////////////4444444444444444444444//////////////////////////////////
			switch(colorPallete) {
			case 1:// RGB
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				actualColorPallete = 1;
				rocketColor = 2;
				break;
			case 2: //GBW
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				actualColorPallete = 2;
				rocketColor = 3;
				break;
			case 3://BWR
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				actualColorPallete = 3;
				rocketColor = 4;
				break;
			case 4://WRG
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				actualColorPallete = 4;
				rocketColor = 1;
				break;
			}
			break;
		case 5://////////////////////////////////////555555555555555555555555555555//////////////////////////////////
			switch(colorPallete) {
			case 1:// RGB
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				actualColorPallete = 1;
				rocketColor = 2;
				break;
			case 2: //GBW
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				actualColorPallete = 2;
				rocketColor = 3;
				break;
			case 3://BWY
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				actualColorPallete = 3;
				rocketColor = 4;
				break;
			case 4://WYR
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				actualColorPallete = 4;
				rocketColor = 5;
				break;
			case 5://YRG
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				actualColorPallete = 5;
				rocketColor = 1;
				break;
			}
			break;
		case 6:
			switch(colorPallete) {
			case 1:// RGB
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				actualColorPallete = 1;
				rocketColor = 2;
				break;
			case 2: //GBW
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				actualColorPallete = 2;
				rocketColor = 3;
				break;
			case 3://BWY
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.blue;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				actualColorPallete = 3;
				rocketColor = 4;
				break;
			case 4://WYM
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.white;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.magenta;
				actualColorPallete = 4;
				rocketColor = 5;
				break;
			case 5://YMR
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.yellow;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.magenta;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				actualColorPallete = 5;
				rocketColor = 6;
				break;
			case 6://MRG
				leftRocket.GetComponent<SpriteRenderer> ().color = Color.magenta;
				middleRocket.GetComponent<SpriteRenderer> ().color = Color.red;
				rightRocket.GetComponent<SpriteRenderer> ().color = Color.green;
				actualColorPallete = 6;
				rocketColor = 1;
				break;
			}
			break;
		}
	}

	public int GetRocketColor () {
		return rocketColor;
	}

	public int GetNumberOfColor () {
		return numberOfColors;
	}

	public void SetNumberOfColor (int numberOfColors) {
		this.numberOfColors = numberOfColors;
	}
}
