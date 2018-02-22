﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControllerTest : MonoBehaviour {
    private Rigidbody pcRigidbody;
    private GameObject pcCamera;


    [SerializeField]
    private float groundAcceleration = 0.5f; //7f is a default but overwriteable value
    [SerializeField]
    private float turnAcceleration = 0.5f;
    [SerializeField]
    private float brakeAcceleration = 0.1f;
    [SerializeField]
    private float jumpForce = 7f;
    [SerializeField]
    private float airMaxSpeed = 6f;
    [SerializeField]
    private float airMaxAccel = .1f;
	[SerializeField]
	private float walkableAngle = 60f;
    private Vector3 currentVelocity;

	private bool isFlying = false;

	public Animator anim;


	private GameObject currentGround;
    // Use this for initialization
    void Start () {
		pcRigidbody = GetComponent<Rigidbody>();
        pcCamera = Camera.main.gameObject;
        
	}

 
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 addForceRight = pcCamera.transform.right * turnAcceleration;
        Vector3 addForceForward = pcCamera.transform.forward * turnAcceleration;

        currentVelocity = pcRigidbody.velocity;

        addForceForward.y = 0;
        addForceRight.y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            currentVelocity += addForceForward;
        }

        if (Input.GetKey(KeyCode.S) && currentVelocity != Vector3.zero)
        {
            currentVelocity -= currentVelocity * brakeAcceleration;
        }

        if (Input.GetKey(KeyCode.D) && currentVelocity != Vector3.zero)
        {
            currentVelocity += addForceRight;
        }

        if (Input.GetKey(KeyCode.A) && currentVelocity != Vector3.zero)
        {
            currentVelocity -= addForceRight;
        }
		anim.SetFloat ("walkSpeed", currentVelocity.z);

        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);



        //ground functions
		if(currentGround != null)
		{	
			anim.SetBool ("Fly", false);


			//pcRigidbody.AddForce (movement * groundSpeed); 

			if (pcRigidbody.velocity.x > 0.0f||pcRigidbody.velocity.z > 0.0f) {
				anim.SetBool ("Walk", true);
			} 

			else {
				anim.SetBool ("Walk", false);
			}
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
            {
                pcRigidbody.velocity = currentVelocity;
            }

            if ((Input.GetKey(KeyCode.Space)))
            {
				
                pcRigidbody.velocity = new Vector3(pcRigidbody.velocity.x, jumpForce, pcRigidbody.velocity.z);


            }

           
			RotateDo ();
        }
        else //if not grounded
		{
			anim.SetBool ("Walk", false);
			anim.SetBool ("Fly", true);
			if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
			{
				pcRigidbody.velocity = AirVelocityAccelerate(pcRigidbody, airMaxAccel, airMaxSpeed);
			}
			RotateDo ();
            

        }
      
    }

    private bool IsGrounded()
    {                                                       //our raycast will touch ground regardless of scale
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y+.1f);
    }

//    private void OnCollisionEnter (Collision hit)
//    {
//        //Debug.Log(hit.collider.name);
//    }

    private void OnCollisionStay (Collision hit)
    {
		ContactPoint contact = hit.contacts [0];
		float hitAngle = Vector3.Angle (Vector3.up, contact.normal);
		if(contact.point.y < transform.position.y -.48f && hitAngle < walkableAngle)
		{
			currentGround = hit.gameObject;
		}
		if (hit.gameObject.tag == "Bouncy") {
			pcRigidbody.velocity = new Vector3(pcRigidbody.velocity.x, jumpForce, pcRigidbody.velocity.z);
		}
    }

    private void OnCollisionExit (Collision hit)
    {
		
		if (hit.collider.gameObject == currentGround) {
			currentGround = null;

		}
    }


    private Vector3 AirVelocityAccelerate(Rigidbody acceleratingBody, float maxAccel, float maxSpeed)
    {

        Vector3 calcVelocity;
        Vector3 dir = acceleratingBody.velocity;
        //cancle out Y velocity
        dir.y = 0;
        float Mag = dir.magnitude;
        dir = Vector3.Normalize(dir);

        //base next tick of acceleration on current momentum
        float currentAccel = maxAccel * (Mag / (maxSpeed + .11f));
        Mag += currentAccel;
        calcVelocity = transform.forward * Mathf.Min(Mag, maxSpeed) + new Vector3(0, acceleratingBody.velocity.y, 0);

        return calcVelocity;
    }

	private void RotateDo()
	{
        Vector3 newRotation = currentVelocity;
        newRotation.y = 0;
		if (newRotation != Vector3.zero) 
		{
			pcRigidbody.MoveRotation(Quaternion.RotateTowards
				(transform.rotation, Quaternion.LookRotation(newRotation.normalized), 1000f * Time.deltaTime));
            newRotation = Vector3.zero;
		}
	}
}
