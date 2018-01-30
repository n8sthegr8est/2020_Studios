using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushController : MonoBehaviour {

	public int health = 3;
	private Animator anim;

	public void DisableMush()
	{
		gameObject.SetActive (false);
	}
}
