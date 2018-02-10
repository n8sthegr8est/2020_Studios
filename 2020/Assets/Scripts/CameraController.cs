using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    [SerializeField]
    private GameObject pcObj;
    [SerializeField]
    private float camDistance = 5f;
    [SerializeField]
    private float camHeight = 2.5f;

    private bool lookBackwards = false;

   
    void Start () {
      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		
	}
	// Update is called once per frame
    private void Update ()
    {   
    }

    private void LateUpdate()
    {
        //Determine if looking backwards if left shift is held down
        lookBackwards = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate () {

        //set our z distance away from the PC
        float zDist = -camDistance;

        //Reverse z distance if looking backwards
        if(lookBackwards)
        {
            zDist *= -1;
        }

        //set new z distance and camera heigh
        Vector3 dir = new Vector3(0, camHeight, zDist);
        //set the rotation of the camera
        Quaternion rotation = pcObj.GetComponent<Rigidbody>().transform.rotation;
       
        //lerp camera positon to new positoin                 -define new position as pc positon, offset by the rotation, 
                                                                                //Move Backwards 

        //multiplying a positiong by a qyaternion rotatest the positon
        transform.position = Vector3.Lerp(transform.position, pcObj.transform.position + rotation * dir, 8f * Time.deltaTime);
        transform.LookAt(pcObj.transform.position);
	}


}
