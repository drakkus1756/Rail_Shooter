using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[Tooltip("in ms^-1")][SerializeField] float xSpeed = 5f;
	[Tooltip("in ms^-1")][SerializeField] float ySpeed = 5f;
	[SerializeField] float xRange = 5f;
	[SerializeField] float yMin = -3f;
	[SerializeField] float yMax = 3f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float yOffset = yThrow * ySpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;
		float rawYPos = transform.localPosition.y + yOffset;

		float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
		float clampedyPos = Mathf.Clamp(rawYPos, yMin, yMax);

		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
		transform.localPosition = new Vector3(transform.localPosition.x, clampedyPos, transform.localPosition.z);		
	}
}
