using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_on_escape : MonoBehaviour {
    [SerializeField]
    private GameObject Menu_Pane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Menu_Pane.activeInHierarchy)
            {
                Menu_Pane.SetActive(true);
            }
            else
            {
                Menu_Pane.SetActive(false);
            }
        }
	}
}
