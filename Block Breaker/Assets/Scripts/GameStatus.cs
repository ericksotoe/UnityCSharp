using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    // config parametrs
    // this serializes the field and allows a range for the slider
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 25;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currScore = 0;

    // We use the Awake method to implement Singleton pattern to keep track of score
    private void Awake() {
        // checking to see how many game objects of type Game status there are 
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            // disables the curr game obj since it is higher in heirarchy than destory
            gameObject.SetActive(false); 
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        scoreText.text = currScore.ToString();
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currScore += pointsPerBlockDestroyed;
        scoreText.text = currScore.ToString();
    }
}
