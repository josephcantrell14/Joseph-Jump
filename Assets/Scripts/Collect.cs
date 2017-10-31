using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour {
    public static int score = 0;

    // Use this for initialization
    void Start() {
        //DontDestroyOnLoad(this);
    }

    private void Update() {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            score += 1;
            GameObject scoreObject = GameObject.Find("score");
            scoreObject.GetComponent<Text>().text = score.ToString();
        }
    }
    
}
