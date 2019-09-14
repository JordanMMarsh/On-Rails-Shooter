using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float xSpeed = 10f;
    [SerializeField] float xRange = 6f;
    [SerializeField] float ySpeed = 10f;
    [SerializeField] float yRange = 3f;

    //Multiplied against the Y position to get rotation for ship
    [SerializeField] float positionPitchFactor = -5f;

    //Multiplied against vertical input to force nose of ship up or down while steering in that direction
    [SerializeField] float controlPitchFactor = -1000f;

    //Multiplied against X position of ship to get rotation for yaw
    [SerializeField] float positionYawFactor = 5f;

    //Multiplied against horizontal input to get ship to roll during movement
    [SerializeField] float controlYawFactor = -50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float horizontalThrow = Mathf.Clamp((Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime) + transform.localPosition.x, -xRange, xRange);
        float verticalThrow = Mathf.Clamp((Input.GetAxis("Vertical") * ySpeed * Time.deltaTime) + transform.localPosition.y, -yRange, yRange);
        transform.localPosition = new Vector3(horizontalThrow, verticalThrow, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) + (Input.GetAxis("Vertical") * controlPitchFactor * Time.deltaTime);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = Input.GetAxis("Horizontal") * controlYawFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected With " + other.name);
    }
}
