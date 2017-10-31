using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject platform;
    public GameObject coin;
    public int maxPlatforms = 20;
    public static int platforms = 0;
    public float sizeMin = 1;
    public float sizeMax = 4;
    public float horizontalMinAbs = 6.5f;
    public float horizontalMaxAbs = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;
    public static Vector2 origin;
    public float bounds = 20f;

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}
    private void FixedUpdate() {
        GameObject player = GameObject.Find("player");
        float distance = origin.y - player.transform.position.y;
        if (distance < 1000) {
            Spawn();
        }
    }

    void Spawn() {
        float xSize = Random.Range(sizeMin, sizeMax);
        platform.transform.localScale = new Vector3(xSize, platform.transform.localScale.y);
        int direction = 0;
        if (Random.Range(1, 3) == 1) {
            direction = -1;
        } else {
            direction = 1;
        }
        float xTranslation = Random.Range(horizontalMinAbs, horizontalMaxAbs) * direction;
        Vector2 randomPosition = origin + new Vector2(xTranslation, Random.Range(verticalMin, verticalMax));
        if (randomPosition.x > bounds) {
            randomPosition.x = bounds - 5;
        } else if (randomPosition.x < -1 * bounds) {
            randomPosition.x = -1 * bounds + 5;
        }
        Instantiate(platform, randomPosition, Quaternion.identity);
        if (Random.Range(1, 4) == 1) {
            Vector2 coinPosition = randomPosition + new Vector2(0, 1);
            Instantiate(coin, coinPosition, Quaternion.identity);
        }
        origin = randomPosition;
        platforms++;
    }
    
}
