using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
	protected Rigidbody pcRigidbody;
	protected GameObject pcCamera;


	protected Vector3 currentRotation;
	protected Vector3 currentVelocity;

	protected bool isGrounded;
	protected bool isTurning;

	public Animator anim;

	void Start () {
		pcRigidbody = GetComponent<Rigidbody>();
		pcCamera = Camera.main.gameObject;
	}

	protected void RotateDo(Vector3 rot)
	{
		rot.y = 0;
		if (rot != Vector3.zero) 
		{
			pcRigidbody.MoveRotation(Quaternion.RotateTowards
				(transform.rotation, Quaternion.LookRotation(rot.normalized), 1000f * Time.deltaTime));
		}
	}

	protected void OnCollisionEnter (Collision hit)
	{
		if (hit.collider.tag == "Track" || hit.collider.tag == "Ground") 
		{
			isGrounded = true;
			anim.SetBool ("Walk", true);
			anim.SetBool ("Fly", false);
		}
	}

	protected void OnCollisionStay (Collision hit)
	{
		if (hit.collider.tag == "Track" || hit.collider.tag == "Ground") 
		{
			isGrounded = true;
			anim.SetBool ("Walk", true);
			anim.SetBool ("Fly", false);
		}
//		ContactPoint contact = hit.contacts [0];
//		float hitAngle = Vector3.Angle (Vector3.up, contact.normal);
//		if(contact.point.y < transform.position.y -.48f && hitAngle < walkableAngle)
//		{
//			currentGround = hit.gameObject;
//		}
//		if (hit.gameObject.tag == "Bouncy") {
//			pcRigidbody.velocity = new Vector3(pcRigidbody.velocity.x, jumpForce, pcRigidbody.velocity.z);
//		}
	}

	protected void OnCollisionExit (Collision hit)
	{

		if (hit.collider.tag == "Ground" || hit.collider.tag == "Track") 
		{
			isGrounded = false;
			anim.SetBool ("Fly", true);
			anim.SetBool ("Walk", false);
		}
	}

}

