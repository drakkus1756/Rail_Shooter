using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;

	void Start () 
	{
        Collider meshCollider = gameObject.AddComponent<MeshCollider>();
		meshCollider.isTrigger = false;
		GetComponent<MeshCollider>().convex = true;		
	}

    void OnParticleCollision (GameObject other)
	{
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}
}
