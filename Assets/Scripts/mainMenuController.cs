using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
            Collect.score = 0;
            SceneManager.LoadScene(1);
        } else if (Input.GetButtonDown("Fire1")) {
            Collect.score = 0;
            SceneManager.LoadScene(3);
        } 
    }
}
