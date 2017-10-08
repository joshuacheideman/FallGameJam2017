using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float timeLeft;
	private Text timerText;
	private GameObject gameManager;
	public float explosionTime;
	private Coroutine lastRoutine = null;
	// Use this for initialization
	void Start () {
		timerText = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text>();
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		lastRoutine = StartCoroutine (countDown ());
	}

	IEnumerator countDown() {
		while (timeLeft >= 0) {
			setText ();
			yield return new WaitForSeconds (1f);
			timeLeft -= 1;
		}
		gameManager.GetComponent<GameManager> ().gameOver ();

	}

	private void setText() {
		timerText.text = timeLeft + " seconds"; 
	}

	public void stopTimer() {
		Debug.Log ("StoppingTimer");
		StopCoroutine (lastRoutine);
	}


		
}
