using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    private bool cycleWaypoints = true; // defaults to true. set to false if non-looping track, add script to check which track it is
	// put the points from unity interface
	public Transform[] wayPointList;

	public int currentWayPoint = 0; 
	Transform targetWayPoint;

	public float speed = 4f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// check if we have somewere to walk
		if(currentWayPoint < this.wayPointList.Length)
		{
			if(targetWayPoint == null)
				targetWayPoint = wayPointList[currentWayPoint];
			walk();
		}
	}

	void walk(){
		// rotate towards the target
		transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);

		// move towards the target
		transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);

		if(transform.position == targetWayPoint.position)
		{
            if(currentWayPoint + 1 == wayPointList.Length && !cycleWaypoints)
            {
                currentWayPoint = currentWayPoint;
            }
            else if(currentWayPoint + 1 != wayPointList.Length)
            {
                currentWayPoint++;
                //targetWayPoint = wayPointList[currentWayPoint];
            }
            else
            {
                currentWayPoint = 0;
                //targetWayPoint = wayPointList[]
            }
			//currentWayPoint ++ ;
			targetWayPoint = wayPointList[currentWayPoint];
		}
	} 
}