using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;

    private void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // getter method that returns the current score
    public int GetScore() {
        return score;
    }

    // this method adds passed in value to current score
    public void AddToScore(int scoreValue) {
        score += scoreValue;
    }

    // this method destroys the singleton game object
    public void ResetGame() {
        Destroy(gameObject);
    }
}
