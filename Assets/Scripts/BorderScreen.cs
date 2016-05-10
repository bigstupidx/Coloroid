using UnityEngine;
using System.Collections;

public class BorderScreen : MonoBehaviour {
	public int locationScreen;
	private Vector2 pos;

	void Start () {
		Vector2 screenSize;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		Vector2 camera = Camera.main.transform.position; 
		switch(locationScreen) {
		case 1: // right
			pos = new Vector2 (camera.x + screenSize.x + (transform.localScale.x * 0.5f),  transform.position.y); // po pridani - zjavi sa na druhej strane
			break;
		case 2: // bottom
			pos = new Vector2 (transform.position.x,  camera.y - screenSize.y - (transform.localScale.y * 0.5f)); // po pridani - zjavi sa na druhej strane
			break;
		case 3: // left
			pos = new Vector2 (camera.x - screenSize.x - (transform.localScale.x * 0.5f),  transform.position.y); // po pridani - zjavi sa na druhej strane
			break;
		}
		transform.position = pos;
		//Vector2 pos = new Vector2 (camera.x + screenSize.x + (transform.localScale.x * 0.5f),  transform.position.y); // po pridani - zjavi sa na druhej strane
		//transform.position = pos;
	}
}
