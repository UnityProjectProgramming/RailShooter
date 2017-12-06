using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("ms^-1")][SerializeField] float xSpeed = 1.0f;
    [Tooltip("ms^-1")][SerializeField] float ySpeed = 1.0f;


    void Start ()
    {
		
	}
	
	void Update ()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -3.8f, 3.8f); //TODO parametarize
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);


        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, -2.5f, 2.9f); //TODO parametarize
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);

    }
}
