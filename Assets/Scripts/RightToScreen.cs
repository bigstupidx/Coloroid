using UnityEngine;
using System.Collections;

public class RightToScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector2 screenSize;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		Vector2 camera = Camera.main.transform.position; 
		Vector2 pos = new Vector2 (camera.x + screenSize.x + (transform.localScale.x * 0.5f),  transform.position.y); // po pridani - zjavi sa na druhej strane
		transform.position = pos;
	}
}
