using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour {
	TextMesh textmesh;
	float curTimeLeft;
	// Use this for initialization
	void Start () {
		curTimeLeft = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer> ().timeLeft;
		textmesh = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		curTimeLeft -= Time.deltaTime;
		if (curTimeLeft >= 0) {
			textmesh.text = curTimeLeft.ToString ();
		}
		else {
			textmesh.text = "B00M";
		}

	}
}
