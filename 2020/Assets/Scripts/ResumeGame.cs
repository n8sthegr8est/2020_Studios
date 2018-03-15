using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour {

	public Button resume;
	//public Button restart;
	public Button quit;
	public Button Pause;


	public void Resume()
	{

		resume.gameObject.SetActive (false);
		//restart.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
		Pause.gameObject.SetActive (true);

		Time.timeScale = 1;



	}

}
