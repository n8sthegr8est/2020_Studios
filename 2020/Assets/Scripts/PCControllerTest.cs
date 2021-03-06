﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControllerTest : Racer {
    
//    [SerializeField]
//    private float groundAcceleration = 0.5f; //7f is a default but overwriteable value
    [SerializeField]
    private float turnAcceleration = 0.5f;
    [SerializeField]
    private float brakeAcceleration = 0.1f;
    [SerializeField]
    private float jumpForce = 7f;
    [SerializeField]
//    private float airMaxSpeed = 6f;
//    [SerializeField]
//    private float airMaxAccel = .1f;
//	[SerializeField]
//	private float walkableAngle = 60f;


//	private bool isFlying = false;


//	private GameObject currentGround;
    // Use this for initialization
    

 
	
	// Update is called once per frame
	void LateUpdate () {
		isTurning = false;

		Vector3 addForceRight = pcCamera.transform.right * turnAcceleration;
        Vector3 addForceForward = pcCamera.transform.forward * turnAcceleration;

		Vector3 previousVelocity = pcRigidbody.velocity.normalized;
		currentVelocity = pcRigidbody.velocity;
		currentRotation = Vector3.zero;

        addForceForward.y = 0;
        addForceRight.y = 0;

        if (Input.GetKey(KeyCode.W))
        {
			currentRotation += addForceForward;
        }

		if (Input.GetKey(KeyCode.S) && currentRotation != Vector3.zero)
        {
			currentRotation -= currentRotation * brakeAcceleration;
        }

		if (Input.GetKey(KeyCode.D) && currentRotation != Vector3.zero)
        {
			currentRotation += addForceRight;
			isTurning = true;
        }

		if (Input.GetKey(KeyCode.A) && currentRotation != Vector3.zero)
        {
			currentRotation -= addForceRight;
			isTurning = true;
        }
			
		currentVelocity += currentRotation;

		if (isTurning) 
		{
			currentVelocity += previousVelocity*0.05f;
		}


		if (Input.GetKey (KeyCode.Space) && isGrounded) 
		{
			currentVelocity.y = jumpForce;
		}

		if (isGrounded) 
		{
			anim.SetFloat ("walkSpeed", currentVelocity.z);
		}

//        float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");

//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		RotateDo (currentRotation);
		pcRigidbody.velocity = currentVelocity;


//		if (Input.GetKey (KeyCode.Space) && isGrounded) {
//			pcRigidbody.velocity = new Vector3(pcRigidbody.velocity.x, pcRigidbody.velocity.y+jumpForce, pcRigidbody.velocity.z);
//		}

        //ground functions
//		if(currentGround != null)
//		{	
//			anim.SetBool ("Fly", false); 
//
//			if (pcRigidbody.velocity.x > 0.0f||pcRigidbody.velocity.z > 0.0f) {
//				anim.SetBool ("Walk", true);
//			} 
//
//			else {
//				anim.SetBool ("Walk", false);
//			}
//            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
//            {
//                pcRigidbody.velocity = currentVelocity;
//            }
//
//            if ((Input.GetKey(KeyCode.Space)))
//            {
//				
//                pcRigidbody.velocity = new Vector3(pcRigidbody.velocity.x, jumpForce, pcRigidbody.velocity.z);
//
//
//            }
//
//           
////			RotateDo ();
//        }
//        else //if not grounded
//		{
//			anim.SetBool ("Walk", false);
//			anim.SetBool ("Fly", true);
//			if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
//			{
//				pcRigidbody.velocity = AirVelocityAccelerate(pcRigidbody, airMaxAccel, airMaxSpeed);
//			}
////			RotateDo ();
//            
//
//        }
      
    }

//    private bool IsGrounded()
//    {                                                       //our raycast will touch ground regardless of scale
//        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y+.1f);
//    }

    

//    private Vector3 AirVelocityAccelerate(Rigidbody acceleratingBody, float maxAccel, float maxSpeed)
//    {
//
//        Vector3 calcVelocity;
//        Vector3 dir = acceleratingBody.velocity;
//        //cancle out Y velocity
//        dir.y = 0;
//        float Mag = dir.magnitude;
//        dir = Vector3.Normalize(dir);
//
//        //base next tick of acceleration on current momentum
//        float currentAccel = maxAccel * (Mag / (maxSpeed + .11f));
//        Mag += currentAccel;
//        calcVelocity = transform.forward * Mathf.Min(Mag, maxSpeed) + new Vector3(0, acceleratingBody.velocity.y, 0);
//
//        return calcVelocity;
//    }


}
