using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;

	ScoreBoard scoreBoard;

	void Start ()
    {
        AddMeshCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddMeshCollider()
    {
        Collider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.isTrigger = false;
        GetComponent<MeshCollider>().convex = true;
    }

    void OnParticleCollision (GameObject other)
	{
		scoreBoard.ScoreHit(scorePerHit);
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}
}
