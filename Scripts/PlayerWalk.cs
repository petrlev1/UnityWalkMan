using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    
	//movement speed in units per second
    public float movementSpeed = 5f;

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
		float horizontalInput2 = Input.GetAxis("Mouse X");
        //get the Input from Vertical axis
		float verticalInput = Input.GetAxis("Vertical");
        float verticalInput2 = Input.GetAxis("Mouse Y");

        //update the position
        transform.localPosition = transform.localPosition + new Vector3( horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime );
		 transform.localPosition = transform.localPosition + new Vector3( horizontalInput2 * movementSpeed * Time.deltaTime, 0, verticalInput2 * movementSpeed * Time.deltaTime );

        //output to log the position change
        //Debug.Log(transform.position);
    }
	
}
