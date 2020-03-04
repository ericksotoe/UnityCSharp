using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float delayInSeconds = 2f;

    // this method loads the start menu
    public void LoadStartMenu() {
        SceneManager.LoadScene(0);
    }

    // this method loads the main game using string literal
    public void LoadGame() {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    // this method loads the game over screen
    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad() {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    // this method quits the application 
    public void QuitGame() {
        Application.Quit();
    }
}
