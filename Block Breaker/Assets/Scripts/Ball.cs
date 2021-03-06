﻿using UnityEngine;

public class Ball : MonoBehaviour {

    // config paramters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 50f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomAngleFactor = 0.13f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    // method used to launch the ball from the paddle
    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            myRigidBody2d.velocity = new Vector2(xPush, yPush);
        }
    }

    // method used to apply the ball object to the top of paddle object
    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomAngleFactor), Random.Range(0f, randomAngleFactor));

        // we are attempting to get the audio source to have it play on collision
        if (hasStarted) {
            AudioClip myClip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(myClip);
            myRigidBody2d.velocity += velocityTweak;
        }

    }
}
