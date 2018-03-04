using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		AddNonTriggerCollider();
	}

    private void AddNonTriggerCollider()
    {
        Collider collider = gameObject.AddComponent<MeshCollider>();
		collider.isTrigger.Equals(false);
		GetComponent<MeshCollider>().convex = true;
    }

    void OnParticleCollision (GameObject other)
	{
		Destroy(gameObject);
	}
}
