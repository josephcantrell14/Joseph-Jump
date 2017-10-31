using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCollider : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }

    private void Update() {
       
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(0, 0);
            rb2d.angularVelocity = 0;
        }
    }
}
