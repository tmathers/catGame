using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour {


    private Rigidbody2D rb2d;

    public float speed;
    public float maxSpeed;
 
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update() {

    }

    // Called before applying any physics update
    void FixedUpdate() {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(inputX, inputY);

        rb2d.AddForce(movement * speed);

        // Clamp the speed to maxSpeed
        if (rb2d.velocity.magnitude > maxSpeed) {
            Debug.Log("Max Speed Reached!!!!!!!");
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
        }

    }
}
