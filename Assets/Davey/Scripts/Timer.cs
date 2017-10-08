using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float timeLeft;
	private Text timerText;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		timerText = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text>();
		StartCoroutine (countDown ());
	}

	IEnumerator countDown() {
		while (timeLeft >= 0) {
			setText ();
			yield return new WaitForSeconds (1f);
			timeLeft -= 1;
		}
		beginExplosion ();
	}

	private void setText() {
		timerText.text = timeLeft + " seconds"; 
	}

	private void beginExplosion() {
		SceneManager.LoadScene (0);
	}
}
