using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Button resume;
	//public Button restart;
	public Button quit;
	public void Pause()
	{
		



		resume.gameObject.SetActive (true);
		//restart.gameObject.SetActive (true);
		quit.gameObject.SetActive (true);
		gameObject.SetActive (false);
		Time.timeScale = 0;
	}
}
