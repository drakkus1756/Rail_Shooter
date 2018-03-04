using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    ParticleSystem ps;

	// Use this for initialization
	void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
	}

    public void ActivateLasers ()
    {

    }

    public void DeactivateLasers ()
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
