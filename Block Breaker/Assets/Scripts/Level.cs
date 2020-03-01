using UnityEngine;

public class Level : MonoBehaviour {

    // available for debugging purposes
    [SerializeField] int breakableBlocks;

    // cached refernce
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks() {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;
        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
