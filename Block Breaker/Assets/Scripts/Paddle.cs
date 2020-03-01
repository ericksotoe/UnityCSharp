﻿using UnityEngine;

public class Paddle : MonoBehaviour {

    // config paramters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // grabs the current x postion of where the mouse is at on the game scene
        float mousePostionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // set the position of our paddlet to be that of vector2 coordinates
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePostionInUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
