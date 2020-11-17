using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCamera : MonoBehaviour {

    public float targetAspect;

    // Start is called before the first frame update
    void Start() {

        // Set the camera scale

        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f) {  
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
