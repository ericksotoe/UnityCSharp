using UnityEngine;

public class Ball : MonoBehaviour {

    // config paramters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 50f;
    [SerializeField] AudioClip[] ballSounds;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // we are attempting to get the audio source to have it play on collision
        if (hasStarted) {
            AudioClip myClip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(myClip);
        }

    }
}
