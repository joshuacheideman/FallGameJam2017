using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
		static GameManager instance;
		public GameObject LightPrefab;
		private float EXPLOSIONTIME = 10f;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Instantiate (LightPrefab);
		if (instance == null)
			instance = this;
		if (instance != this)
			Destroy(gameObject);
	}
	
	public void LoadNextScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RedoStage()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
			{
				RedoStage();
			}
	}
	public void gameOver() {
		StartCoroutine(playExplosion());
	}

	public IEnumerator playExplosion() {
		int oldSceneIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (0);
		float explosionTimeLeft = EXPLOSIONTIME;
		while (explosionTimeLeft >= 0) {
			if (Input.GetKey(KeyCode.Escape)) {
				SceneManager.LoadScene (oldSceneIndex);
				yield break;
			}
			yield return new WaitForSeconds (.5f);
			explosionTimeLeft -= .5f;
		}
		SceneManager.LoadScene (oldSceneIndex);
	}
}
