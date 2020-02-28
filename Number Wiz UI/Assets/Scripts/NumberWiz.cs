using UnityEngine;
using TMPro;

public class NumberWiz : MonoBehaviour {

    // SerializeField is used to add this property to unity
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    // Start is called before the first frame update
    void Start() {
        StartGame();
    }

    // initializes the variables used for the game
    void StartGame() {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    // updates the guess and sets our new min to the old guess
    public void OnPressHigher() {
        NextGuess("up");
    }

    // updates the guess and sets our new max to the old guess
    public void OnPressLower() {
        NextGuess("down");
    }

    // resets the game
    public void OnPressSuccess() {
        max = 1000;
        min = 1;
        guess = 500;
        StartGame();
    }

    // used for updating the guess and the new max or min
    void NextGuess(string command) {
        if (command == "up") {
            min = guess + 1;
        } else {
            max = guess + 1;
        }
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}
