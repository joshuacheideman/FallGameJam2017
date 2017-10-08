using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelObject : MonoBehaviour {
	private GameObject gameManager;
	private AudioSource completionSound;
	private void Start() {
		completionSound = GetComponent<AudioSource> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Going to next level");
		completionSound.Play ();
		StartCoroutine (nextLevel ());

	}

	IEnumerator nextLevel() {
		GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer> ().stopTimer ();
		GameObject.FindGameObjectWithTag ("BombTimer").GetComponent<BombTimer> ().enabled = false;

		yield return new WaitForSeconds (3f);

		gameManager.GetComponent<GameManager> ().LoadNextScene ();
	}
}
