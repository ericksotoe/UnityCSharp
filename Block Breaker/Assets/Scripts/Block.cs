using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    // cached refernce
    Level level;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.CountBlocks();
        }
    }

    // method used to find out when there is a collision with the block
    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            gameObject.SetActive(false);
            DestroyBlock();
        }
    }

    // when the block object is destroyed play the break sound and destroy the block at 1.5% volume
    private void DestroyBlock() {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.015f);
        gameObject.SetActive(false);
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.BlockDestroyed();
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
