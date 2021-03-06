﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;
	[SerializeField] int hits = 8;

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
        ProcessHit();

        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--; // subtract 1 from hits
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
