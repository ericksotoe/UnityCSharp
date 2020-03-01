using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    // cached refernce
    Level level;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    // method used to find out when there is a collision with the block
    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    // when the block object is destroyed play the break sound and destroy the block at 1.5% volume
    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.015f);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
