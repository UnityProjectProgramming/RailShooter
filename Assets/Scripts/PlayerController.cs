using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("ms^-1")][SerializeField] float xSpeed = 1.0f;
    [Tooltip("ms^-1")][SerializeField] float ySpeed = 1.0f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -6.0f;
    [SerializeField] float positionYawFactor = 8;

    [Header("Control-Throw Based")]
    [SerializeField] float controlRollFactor = -20;
    [SerializeField] float controlPitchFactor = -20.0f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
	void Update ()
    {
        if(isControlEnabled)
        {
            ProccessTranslation();
            ProccessRotation();
        }
    }

    private void ProccessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -7.10f, 7.10f); //TODO parametarize
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, -4.8f, 4.8f); //TODO parametarize
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }

    private void ProccessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        
        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath() // Called by string reference.
    {
        isControlEnabled = false;
    }

}
