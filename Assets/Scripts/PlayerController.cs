using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // TODO: fix burst of speed at the beginning and slow down towards to middle-end

    [Header("General")]
	[Tooltip("in ms^-1")][SerializeField] float xControlSpeed = 20f;
	[Tooltip("in ms^-1")][SerializeField] float yControlSpeed = 18f;
	[SerializeField] float xRange = 5f;
	[SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] lasers;

    [Header("Screen-position Based")]
	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float positionYawFactor = 5f;
	
    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    private ParticleSystem particleSys;

    bool isControlEnabled = true;

    void Start ()
    {
        particleSys = GetComponent<ParticleSystem>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
		    ProcessRotation();
            ProcessFiring();
        }
    }

    void OnPlayerDeath() // called by string reference
    {
        isControlEnabled = false;
    }

    void ProcessRotation()
    {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    	float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;

		float yaw = transform.localPosition.x * positionYawFactor;

		float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    	float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xControlSpeed * Time.deltaTime;
        float yOffset = yThrow * yControlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedyPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedyPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            //particleSys.emission.enabled.Equals(true);
            laser.SetActive(true);
        }
    }

    private void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
}
}
