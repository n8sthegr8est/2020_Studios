using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    [SerializeField]
    private GameObject pcObj;
    [SerializeField]
    private float camDistance = 5f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

   
    void Start () {
      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		
	}
	// Update is called once per frame
    private void Update ()
    {   
        //take in axis info from our mouse movement
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
    }


	private void FixedUpdate () {

        //set our z distance away from the PC
        Vector3 dir = new Vector3(0, 0, -camDistance);
        //set the rotation of the camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
       
        //lerp camera positon to new positoin                 -define new position as pc positon, offset by the rotation, 
                                                                                //Move Backwards 

        //multiplying a positiong by a qyaternion rotatest the positon
        transform.position = Vector3.Lerp(transform.position, pcObj.transform.position + rotation * dir, 8f * Time.deltaTime);
        transform.LookAt(pcObj.transform.position);
	}


}
