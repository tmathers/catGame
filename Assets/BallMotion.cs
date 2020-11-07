using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour {


    private Rigidbody2D rb2d;
    private AudioSource hitSound;
    private Collider2D ballCollider;

    public float speed;
    public float maxSpeed;

    // If the velocity is between +/- this, then change the direction randomly
    private float zeroVelocitySensitivity = 1.0f;
 
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
        ballCollider = GetComponent<Collider2D>();

        // set the ball's initial speed
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();  

        rb2d.velocity = direction * speed;
    }
 
    // Update is called once per frame
    void Update() {
        
        // Detect touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            hit(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));

        }

        // Detect mouse input
        if (Input.GetMouseButtonDown(0)) {

            hit(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }

    // When the ball is hit
    private void hit(Vector2 point) {

        // Check if there is a collision
        if (collider2D.OverlapPoint(point)) {
            Debug.Log("Collision Detected !");
            hitSound.Play();
        }
    }

    // Called before applying any physics update
    void FixedUpdate() {

        /*float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(inputX, inputY);

        rb2d.AddForce(movement * speed);
*/
        // Clamp the speed to maxSpeed
        if (rb2d.velocity.magnitude > maxSpeed) {
            //Debug.Log("Max Speed Reached!!!!!!!");
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
        }

        Debug.Log("X = " + rb2d.velocity.x + ", Y = " + rb2d.velocity.y);


        if (rb2d.velocity.x < zeroVelocitySensitivity && rb2d.velocity.x > -zeroVelocitySensitivity) {
            //Debug.Log("X is around 0");
            Vector2 movement = new Vector2(Random.Range(-1f, 1f) * speed, rb2d.velocity.y);
            rb2d.AddForce(movement * speed);
        }
        if (rb2d.velocity.y < zeroVelocitySensitivity && rb2d.velocity.y > -zeroVelocitySensitivity) {
            //Debug.Log("Y is around 0");
            Vector2 movement = new Vector2(rb2d.velocity.x, Random.Range(-1f, 1f) * speed);
            rb2d.AddForce(movement * speed);
        }




    }
}
