using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathMenuController : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GameObject scoreObject = GameObject.Find("Score");
        scoreObject.GetComponent<Text>().text = Collect.score.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Submit")) {
            Collect.score = 0;
            SpawnManager.origin = new Vector2(0, 0);
            SceneManager.LoadScene(1);
        }
    }
}
