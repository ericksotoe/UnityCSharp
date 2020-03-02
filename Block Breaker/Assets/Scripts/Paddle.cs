using UnityEngine;

public class Paddle : MonoBehaviour {

    // config paramters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15f;

    // cached refernce
    GameSession myGameSession;
    Ball myBall;

    // Start is called before the first frame update
    void Start() {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        // grabs the current x postion of where the mouse is at on the game scene
        // float mousePostionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // set the position of our paddlet to be that of vector2 coordinates
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPosition() {
        if (myGameSession.IsAutoPlayEnabled()) {
            return myBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
