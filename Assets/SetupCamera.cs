using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCamera : MonoBehaviour {


    // Start is called before the first frame update
    void Start() {


        // Setup the edge collider points to the edges of the screen

        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
        List<Vector2> newVerticies = new List<Vector2>();

        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        Vector2 halfScreen = new Vector2(width, height);

        newVerticies.Add( new Vector2(-halfScreen.x, -halfScreen.y) );
        newVerticies.Add( new Vector2(halfScreen.x, -halfScreen.y) );
        newVerticies.Add( new Vector2(halfScreen.x, halfScreen.y) );
        newVerticies.Add( new Vector2(-halfScreen.x, halfScreen.y) );
        newVerticies.Add( new Vector2(-halfScreen.x, -halfScreen.y) );

        collider.points = newVerticies.ToArray();
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
