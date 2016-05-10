using UnityEngine;
using System.Collections;

public class BallTextScript : MonoBehaviour {
	private TextMesh textMesh;
	public int ballNumber = 1;

	// Use this for initialization
	void Start () {
		try {
			textMesh = GetComponentInChildren<TextMesh>();
			textMesh.text = ballNumber.ToString();
		} catch {
			Debug.Log("text == null");
		}
	}
}
