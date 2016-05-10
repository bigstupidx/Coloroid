using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class DetectClickOnBall : MonoBehaviour {
	private GameObject selectedObject = null;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) { // ziskam prvu suradnicu , nasledne sa nacitaju vsetky dostupne uzly podla pozicie ydvihnutia kliku sa urci na ktoru stranu sa vzdat
			ClickMousePlayer();
			print ("Click down");
			Destroy (selectedObject);
		}
	}

	private void ClickMousePlayer() {
		Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D[] hits = Physics2D.LinecastAll(clickPosition, clickPosition);

		if(hits.Length != 0) {
			selectedObject = hits[0].collider.gameObject;
			for(int i = 1; i < hits.Length; i++) {
				try {
					if(hits[i].collider.gameObject.GetComponent<Renderer>().sortingOrder >= selectedObject.GetComponent<Renderer>().sortingOrder) {
						selectedObject = hits[i].collider.gameObject;
					}
				} catch {
					Debug.Log("there is no renderer soldier clone");
				}
			}
		}
	}
}

