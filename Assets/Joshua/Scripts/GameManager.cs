using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
		static GameManager instance;
		public GameObject LightPrefab;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Instantiate (LightPrefab);
		if (instance == null)
			instance = this;
		if (instance != this)
			Destroy(gameObject);
	}
	
	public void LoadNextScene(int SceneNo)
	{
		SceneManager.LoadScene (SceneNo);
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
}
