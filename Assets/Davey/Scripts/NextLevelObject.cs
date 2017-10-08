﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelObject : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Going to next level");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
