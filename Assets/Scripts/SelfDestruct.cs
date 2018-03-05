using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    [SerializeField] float destructDelay = 5f;

	// Use this for initialization
	void Start () 
	{
	Destroy(gameObject, destructDelay);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
