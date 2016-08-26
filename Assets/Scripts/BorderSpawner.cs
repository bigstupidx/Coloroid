using UnityEngine;
using System.Collections;

public class BorderSpawner : MonoBehaviour {
	private int numberOfBorders = 2;
	public GameObject prefabBorder;

	// Use this for initialization
	void Start () {
		CreateBorder ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreateBorder() {
		switch(numberOfBorders) {
		case 2: 
			GameObject borderObject;
			/*borderObject = Instantiate (prefabBorder, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.identity) as GameObject;
			borderObject.name = "Border1";
			borderObject.GetComponent<DrawGameBorder> ().parentName = "Border1";*/
			borderObject = Instantiate (prefabBorder, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.identity) as GameObject;
			borderObject.name = "Border2";
			borderObject.GetComponent<DrawGameBorder> ().parentName = "Border2";
			borderObject.GetComponent<DrawGameBorder> ().DeltaStart = 180.0f;
			break;
		}
	}
}
