using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour {

	[Tooltip("In seconds")][SerializeField] float levelLoadDelay = 2f;
	[Tooltip("FX prefab on player")][SerializeField] GameObject deathFx;

	void OnTriggerEnter(Collider other) 
	{
		StartDeathSequence();
		deathFx.SetActive(true);
		Invoke("ReloadLevel", levelLoadDelay);
	}

	private void ReloadLevel() // string references
	{
		SceneManager.LoadScene(1);
	}

    private void StartDeathSequence()
    {
		SendMessage("OnPlayerDeath");
    }
}
