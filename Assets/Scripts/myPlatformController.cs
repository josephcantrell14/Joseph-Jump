using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myPlatformController : MonoBehaviour {

    public GameObject platform;
    private bool jump = false;
    public bool facingRight = false;
    public float moveForce = 2000f;
    public float maxSpeed = 20f;
    public float jumpForce = 666f;
    public Transform groundCheck;

    private bool grounded = false;
    public float dieThreshold = 2f;
    private float oldY = 0;
    private float totalDown;
    private Animator anim;
    private Rigidbody2D rb2d;
    private float fireTotal;
    private int fire;
    private int fireCost = 20;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Fire();
        }
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        if (h * rb2d.velocity.x < maxSpeed) {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (h > 0 && !facingRight) {
            Flip();
        } else if (h < 0 && facingRight) {
            Flip();
        }
       if (jump) {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        float deltaY = rb2d.position.y - oldY;
        if (rb2d.position.y < oldY) {
            totalDown += Mathf.Abs(deltaY);
        } else {
            totalDown = 0;
        }
        if (totalDown > dieThreshold) {
            Die();
        }
        oldY = rb2d.position.y;
        fireTotal += deltaY;
        if (fireTotal >= fireCost) {
            fireTotal -= fireCost;
            fire += 1;
        }
        fireCost = 25 * (fire + 1);
        GameObject fireObject = GameObject.Find("fire");
        fireObject.GetComponent<Text>().text = fire.ToString();
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Fire() {
        if (fire > 0) {
            Vector2 spawnPosition = new Vector2(rb2d.position.x, rb2d.position.y - 1);
            Instantiate(platform, spawnPosition, Quaternion.identity);
            fire -= 1;
        }
    }
    
    public void Die() {
        SceneManager.LoadScene(2);
    }

}
