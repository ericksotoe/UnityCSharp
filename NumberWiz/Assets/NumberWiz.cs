using UnityEngine;

public class NumberWiz : MonoBehaviour {

    int max = 1000;
    int min = 1;
    int guess = 500;

    // Start is called before the first frame update
    void Start() {
        StartGame();
    }

    void StartGame() {
        Debug.Log("Pick a number between " + min + " and " + max);
        Debug.Log("Push up arrow if your guess is higher and down arrow if its lower");
        max += 1;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            NextGuess("min");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            NextGuess("max");
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("GG");
            max = 1000;
            min = 1;
            guess = 500;
            StartGame();
        }

    }

    void NextGuess(string command) {
        if (command == "min") {
            min = guess;
        } else {
            max = guess;
        }
        guess = (max + min) / 2;
        Debug.Log("Is your number higher or lower? " + guess);
    }
}
