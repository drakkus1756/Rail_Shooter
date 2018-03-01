using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
		Invoke("LoadFirstScene", 5f);
	}
	
	void LoadFirstScene()
	{
		SceneManager.LoadScene(1);
	}
}
