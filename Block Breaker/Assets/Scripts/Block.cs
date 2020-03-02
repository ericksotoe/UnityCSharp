using System;
using UnityEngine;

public class Block : MonoBehaviour {

    // config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached refernce
    Level level;

    // state variables
    [SerializeField] int timesHit; // TODO serialized for debugging

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
            HandleCollision();
        }
    }

    private void HandleCollision() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            gameObject.SetActive(false);
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Attempting to access block sprite not in array, obj name is " + gameObject.name);
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
