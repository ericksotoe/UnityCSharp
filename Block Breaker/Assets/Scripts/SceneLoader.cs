using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene() {
        // we are able to get the index of the current scene and load next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
