using UnityEngine;
using System.Collections;

public class CircleBlock : MonoBehaviour {
	
	private GameObject gameController;
	public int colorIndex = 0;

	// Use this for initialization
	void Start () {
		if (gameController == null) {
			gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
	}

	public void SetColor() {
		if (gameController == null) {
			gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
		this.gameObject.GetComponent<SpriteRenderer>().color = gameController.GetComponent<Controller>().ReturnColorFromColorList(colorIndex);
	}

	public int GetColorIndex() {
		return colorIndex;
	}
}
