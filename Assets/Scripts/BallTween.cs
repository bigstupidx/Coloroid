﻿using UnityEngine;
using System.Collections;

public class BallTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.RotateTo (gameObject, iTween.Hash("rotation", new Vector3(0f,0f,270f),"time",1f,"looptype",iTween.LoopType.pingPong, "easetype", iTween.EaseType.linear));
	}
}
