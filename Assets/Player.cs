using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float xSpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float yRange = 5f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalThrow = Mathf.Clamp((Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime) + transform.localPosition.x,-xRange,xRange);
        float verticalThrow = Mathf.Clamp((Input.GetAxis("Vertical") * ySpeed * Time.deltaTime) + transform.localPosition.y,-yRange,yRange);
        transform.localPosition = new Vector3(horizontalThrow, verticalThrow, transform.localPosition.z);
	}
}
