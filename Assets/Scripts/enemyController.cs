using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public myPlatformController playerController;
    private Rigidbody2D rb2d;
    public Vector2 velocity = new Vector2(10, 0);
    public int direction = 1;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("player");
        GameObject enemy = GameObject.Find("enemy");
        if (player.transform.position.y - enemy.transform.position.y > 10) {
            int yScale = Random.Range(1, 5);
            if (Random.Range(1, 3) == 1) {
                direction = -1;
                velocity = new Vector2(-10, 0);
            } else {
                direction = 1;
                velocity = new Vector2(10, 0);
            }
            enemy.transform.position = new Vector2(player.transform.position.x - 27 * direction, player.transform.position.y + 2 + yScale);
        }
        rb2d.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<myPlatformController>().Die();
        }
    }
}
